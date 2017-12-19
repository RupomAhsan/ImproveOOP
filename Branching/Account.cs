using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branching
{
    public class Account
    {
        public decimal Balance { get; set; }

        private IAccountState State { get; set; }

        private Account(Action onUnfreeze)
        {
            this.State = new NotVerified(onUnfreeze);
        }

        // TODO #1: Deposit 50, Close, Deposit 1- Balance==50
        // TODO #2: Deposit 50,  Deposit 1- Balance==51
        // TODO #6: Deposit 50, Freeze, Deposit 1- OnUnfreeze was called
        // TODO #7: Deposit 50, Freeze, Deposit 1- IsFrozen==false
        // TODO #8: Deposit 50, Deposit 1- OnUnfreeze was not called
        public void Deposit(decimal amount)
        {
            //Deposit money
            this.State=this.State.Deposit(()=> { this.Balance += amount; });
        }

        // TODO #3: Deposit 50,  Withdraw 1- Balance==50
        // TODO #4: Deposit 50, Verify, Close, Withdraw 1- Balance==50
        // TODO #5: Deposit 50, Verify, Withdraw 1- Balance==49
        // TODO #9: Deposit 50, Verify,Freeze, Withdraw 1- OnUnfreeze was called
        // TODO #10: Deposit 50, Verify,Freeze, Withdraw 1- IsFrozen==false
        // TODO #11: Deposit 50, Verify, Withdraw 1- OnUnfreeze was not called
        public void Withdraw(decimal amount)
        {
            //Whithdraw money
            this.State = this.State.Withdraw(()=> { this.Balance -= amount; });
        }

        public void HolderVerified()
        {
            this.State = this.State.HolderVerified();
        }

        public void Close()
        {
            this.State = this.State.Close();
        }

        public void Freeze()
        {
            this.State = this.State.Freeze();
        }
    }
}

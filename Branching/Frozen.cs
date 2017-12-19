using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branching
{
    class Frozen : IAccountState
    {

        private Action OnUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }       

        public IAccountState Freeze() => this;

        public IAccountState Deposit(Action addToBalance)
        {
            this.OnUnfreeze();
            addToBalance();
            return new Active(this.OnUnfreeze);
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            this.OnUnfreeze();
            subtractFromBalance();
            return new Active(this.OnUnfreeze);
        }

        public IAccountState HolderVerified()
        {
            throw new NotImplementedException();
        }

        public IAccountState Close()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branching
{
    class Closed : IAccountState
    {
        public IAccountState Close() => this;
        public IAccountState Deposit(Action addToBalance) => this;
        public IAccountState Withdraw(Action subtractFromBalance) => this;
        public IAccountState Freeze() => this;
        public IAccountState HolderVerified() => this;
    }
}

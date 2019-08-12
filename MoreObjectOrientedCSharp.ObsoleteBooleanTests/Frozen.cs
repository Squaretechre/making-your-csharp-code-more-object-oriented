using System;

namespace MoreObjectOrientedCSharp.ObsoleteBooleanTests
{
    public class Frozen : IAccountState
    {
        private Action OnUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

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

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => this;

        public IAccountState Close() => new Closed();
    }
}

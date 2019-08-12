using System;

namespace MoreObjectOrientedCSharp.ObsoleteBooleanTests
{
    public class NotVerified : IAccountState
    {
        private Action OnUnfreeze { get; }

        public NotVerified(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IAccountState Close() => new Closed();

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => new Active(this.OnUnfreeze);

        public IAccountState Withdraw(Action subtractFromBalance) => this;
    }
}

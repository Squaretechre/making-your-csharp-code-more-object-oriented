using System;

namespace MoreObjectOrientedCSharp.ObsoleteBooleanTests
{
    public class Account
    {
        public decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }
        private bool IsFrozen { get; set; }

        private Action OnUnfreeze { get; }
        private Action ManageUnfreezing { get; set; }

        public Account(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
            this.ManageUnfreezing = this.StayUnfrozen;
        }

        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return; // Or do something else... 
            ManageUnfreezing();
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified)
                return; // Or do something else...
            if (this.IsClosed)
                return; // Or do something else... 
            ManageUnfreezing();
            this.Balance -= amount;
        }

        private void StayUnfrozen()
        {
            // Do nothing
        }

        private void Unfreeze()
        {
            this.IsFrozen = false;
            this.OnUnfreeze();
        }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }

        public void Close()
        {
            this.IsClosed = true;
        }

        public void Freeze()
        {
            if (this.IsClosed)
            {
                return; // Account must not be closed
            }
            if (!this.IsVerified)
                return; // Account must be verified
            this.IsFrozen = true;
            this.ManageUnfreezing = this.Unfreeze;
        }
    }
}

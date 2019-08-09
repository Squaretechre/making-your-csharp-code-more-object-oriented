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

        public Account(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        // How many different ways are there to execute the Deposit method?
        // How many unit tests are required?

        // #1:  Deposit 10, Close, Deposit 1             - result: Balance == 10
        // #2:  Deposit 10, Deposit 1                    - result: Balance == 11
        // #6:  Deposit 10, Freeze, Deposit 1            - result: IsFrozen == false
        // #7:  Deposit 10, Freeze, Deposit 1            - result: OnUnfreeze was called
        // #8:  Deposit 10, Deposit 1                    - result: OnUnfreeze was not called
        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return; // Or do something else... 
            ManageUnfreezing();
            this.Balance += amount;
        }

        // How many different ways are there to execute the Withdraw method?
        // How many unit tests are required?

        // #3:  Deposit 10, Withdraw 1                   - result: Balance == 10
        // #4:  Deposit 10, Verify, Close, Withdraw 1    - result: Balance == 10
        // #5:  Deposit 10, Verify, Withdraw 1           - result: Balance == 9
        // #9:  Deposit 10, Verify, Freeze, Withdraw 1   - result: OnUnfreeze was called
        // #10: Deposit 10, Verify, Freeze, Withdraw 1   - result: IsFrozen == false
        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified)
                return; // Or do something else...
            if (this.IsClosed)
                return; // Or do something else... 
            ManageUnfreezing();
            this.Balance -= amount;
        }

        private void ManageUnfreezing()
        {
            if (this.IsFrozen)
            {
                Unfreeze();
            }
            else
            {
                this.StayUnfrozen();
            }
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
        }
    }
}

using System;

namespace Demo_Destructor_FW
{

    // Example of implementing the IDisposable Interface according to the Dispose Pattern
    internal class Organization
        : IDisposable
    {

        private bool isDisposed;

        protected virtual void Dispose ( bool disposing )
        {
            if ( !isDisposed )
            {
                if ( disposing )
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                isDisposed = true;
            }
        }

        public void Dispose ()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose( disposing: true );
            GC.SuppressFinalize( this );
        }

        ~Organization ()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose( disposing: false );
        }

    }
}

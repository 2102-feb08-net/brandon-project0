
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Project0;


namespace Project0.Data
{
    /// <summary>
    /// This class manages the creation and disposal of contexts
    /// </summary>
    public class Dependencies : IDisposable
    {
        private bool _disposedValue;

        private readonly List<IDisposable> _disposables = new List<IDisposable>();

        public Project0SQLDBContext CreateDBContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Project0SQLDBContext>();
            var connectionString = File.ReadAllText("C:/revature/project0-connection-string.txt");
            optionsBuilder.UseSqlServer(connectionString);

            return new Project0SQLDBContext(optionsBuilder.Options);
        }

        public IProject0Repository CreateRepository()
        {
            var context = CreateDBContext();
            _disposables.Add(context);
            return new Project0Repository(context);
        }

        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    foreach (IDisposable disposable in _disposables)
                    {
                        disposable.Dispose();
                    }
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
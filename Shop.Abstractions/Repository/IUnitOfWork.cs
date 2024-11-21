using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Abstractions.Repository;
public interface IUnitOfWork
{
    IBaseRepository<T> Repository<T>() where T : class;
    Task SaveChangesAsync();
}

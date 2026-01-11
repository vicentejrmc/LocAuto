using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocAuto.Dominio.Compartilhado;

public interface IUnitOfWork
{
    public void Commit();
    public void Rollback();

}

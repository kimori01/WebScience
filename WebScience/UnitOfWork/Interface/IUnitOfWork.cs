using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebScience.Models;

namespace WebScience.UnitOfWork.Interface
{
    public interface IUnitOfWork 
    {
        IGenericRepository<tb_UserProfile> UserProfileRepository { get; }
        //ICatRepository CatRepository { get; }

    }
}
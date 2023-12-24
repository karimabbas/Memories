using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Migrations;
using Server.Models;

namespace Server.Services
{
    public interface IGlobalService<T>
    {
        List<T> GetAll();
        bool Create(int id,T t);

    }
}
﻿using System;
using AccountsModelCore.Interfaces.BusinessEntities;

namespace AccountLib.Model.BusinessEntities
{
    public class Person : BusinessEntity, IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Gender { get; set; }
    }
}

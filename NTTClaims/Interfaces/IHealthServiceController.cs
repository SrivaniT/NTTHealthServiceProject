using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NTTClaims.Interfaces
{
    interface IHealthServiceController
    {
        public DataTable GetMemberByID(int memberID);
        public DataTable GetClaimsID(int memberID);
        public DataTable GetAllClaimsDetails();
        public DataTable GetClaimsDetailsByDate(DateTime date);
    }
}

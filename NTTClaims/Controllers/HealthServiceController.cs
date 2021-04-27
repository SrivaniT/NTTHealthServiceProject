using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NTTClaims.DataObjects;
using NTTClaims.Interfaces;
using OfficeOpenXml;
using OfficeOpenXml.Core.ExcelPackage;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTTClaims.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthServiceController : ControllerBase, IHealthServiceController
    {
        private IConfiguration _config;
        private string connectionString;
        public HealthServiceController(IConfiguration config)
        {
            _config = config;
            connectionString = _config.GetConnectionString("NTTHealthService");
        }

        //Member By ID
        [HttpGet]
        [Route("MemberByID")]
        public DataTable GetMemberByID(int memberID)
        {
            DataTable _dtMember = new DataTable();
            try
            {
                MemberDO _member = new MemberDO(_config);
                _member.GetMemberbyID(memberID, _dtMember);
                return _dtMember;
            }

            catch (Exception ex)
            {
                //write log information
                Console.Write(ex.Message);
            }
            finally
            {
                _dtMember.Dispose();
            }
            return _dtMember;
        }

        //Claims by ID
        [HttpGet]
        [Route("ClaimsByID")]
        public DataTable GetClaimsID(int memberID)
        {
            DataTable _dtClaim = new DataTable();
            try
            {
                ClaimsDO _claim = new ClaimsDO(_config);
                _claim.GetClaimbyID(memberID, _dtClaim);
                return _dtClaim;
            }

            catch (Exception ex)
            {
                //write log information
                Console.Write(ex.Message);
            }
            finally
            {
                _dtClaim.Dispose();
            }
            return _dtClaim;
        }

        //Claims by ID
        [HttpGet]
        [Route("AllClaimsDetails")]
        public DataTable GetAllClaimsDetails()
        {
            DataTable _dtClaim = new DataTable();
            try
            {
                ClaimsDO _claim = new ClaimsDO(_config);
                _claim.GetAllClaimsDetails(_dtClaim);
                return _dtClaim;
            }

            catch (Exception ex)
            {
                //write log information
                Console.Write(ex.Message);
            }
            finally
            {
                _dtClaim.Dispose();
            }
            return _dtClaim;
        }

        //Claims by Date
        [HttpGet]
        [Route("ClaimsDetailsByDate")]
        public DataTable GetClaimsDetailsByDate(DateTime date)
        {
            DataTable _dtClaim = new DataTable();
            try
            {
                ClaimsDO _claim = new ClaimsDO(_config);
                _claim.GetClaimsDetailsByDate(_dtClaim, date);
                return _dtClaim;
            }

            catch (Exception ex)
            {
                //write log information
                Console.Write(ex.Message);
            }
            finally
            {
                _dtClaim.Dispose();
            }
            return _dtClaim;
        }

    }
}

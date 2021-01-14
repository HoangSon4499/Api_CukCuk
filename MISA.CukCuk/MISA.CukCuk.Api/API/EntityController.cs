using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Api.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.API
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class EntityController<MISAEntity> : ControllerBase
    {
        #region Declare
        // khai báo kết nối tới DB
        protected DbConnector _dbConnector;
        #endregion

        #region Constructor
        public EntityController()
        {
            _dbConnector = new DbConnector();
        }
        #endregion

        #region Method
        /// <summary>
        /// hàm lấy toàn bộ dữ liệu 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Get()
        // virtual cho phép lớp con có thể ghi đè
        {
            // lấy dữ liệu từ DB
            var entities = _dbConnector.Get<MISAEntity>();
            // trả dữ liệu cho client
            return Ok(entities);
        }

        /// <summary>
        /// lấy dữ liệu nhóm khách hàng theo id
        /// </summary>
        /// <param name="id">id của nhóm khách hàng</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {

            // var dynamicParameters = new DynamicParameters(); cách 2: lấy dữ liệu khách hàng theo id
            // dynamicParameters.Add("@CustomerGroupId",id);
            // Thực hiện Query lấy dữ liệu: cách 2 lấy dữ liệu khách hàng theo id
            // var customerGroup = _dbConnection.Query<CustomerGroup>($"SELECT * FROM CustomerGroup WHERE CustomerGroupId='{id.ToString()}'").FirstOrDefault();

            // lấy dữ liệu từ DB
            var entity = _dbConnector.GetById<MISAEntity>(id);
            // trả dữ liệu cho client
            return Ok(entity);
        }


        #endregion
    }
}

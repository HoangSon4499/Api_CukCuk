using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Models
{
    public class DbConnector
    {
        #region Declare
        // khai báo kết nối tới DB
        string _connectionString = "Host=103.124.92.43;" +
                                "Port= 3306;" +
                                "Database=MISACukCuk_MF659_NHSON;" +
                                "User Id=nvmanh;" +
                                "Password=12345678";
        IDbConnection _dbConnection;
        #endregion

        #region Constructor
        public DbConnector()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        /// <summary>
        /// hàm lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MISAEntity> Get<MISAEntity>()
        {
            string tableName = typeof(MISAEntity).Name;
            // lấy dữ liệu từ DB
            var entities = _dbConnection.Query<MISAEntity>($"SELECT * FROM {tableName}", commandType: CommandType.Text);
            // trả dữ liệu cho client
            return entities;
        }

        public MISAEntity GetById<MISAEntity>(Guid entityId)
        {
            string tableName = typeof(MISAEntity).Name;
            // Thực hiện Query lấy dữ liệu
            var entity = _dbConnection.Query<MISAEntity>($"SELECT * FROM {tableName} WHERE {tableName}Id='{entityId.ToString()}'").FirstOrDefault();
            // trả về phía client
            return entity;
        }
        
        /// <summary>
        /// thêm dữ liệu mới vào DB
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public int Insert<MISAEntity>(MISAEntity entity)
        {
            var _dbConnection = new MySqlConnection();
            string tableName = typeof(MISAEntity).Name;
            DynamicParameters dynamic = new DynamicParameters();
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyVualue = property.GetValue(entity);
                if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
                {
                    propertyVualue = property.GetValue(entity).ToString();
                }
                dynamic.Add($"@{propertyName}",propertyVualue);
            }
            // thực hiện câu lệnh truy vấn mới vào DB
            var recordAfects = _dbConnection.Execute($"Proc_Isert{tableName}", commandType: CommandType.StoredProcedure, param: dynamic);
            // trả kết quả cho client
            return recordAfects;
        }
        #endregion
    }
}

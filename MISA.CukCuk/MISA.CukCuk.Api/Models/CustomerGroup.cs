using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Models
{
    /// <summary>
    /// Nhóm khách hàng
    /// Created by: NHSON(14-1-2-21)
    /// </summary>
    public class CustomerGroup
    {
        #region Declare

        #endregion

        #region Constructor

        #endregion

        #region Method

        #endregion

        #region Property
        /// <summary>
        /// khóa chính
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }


        /// <summary>
        /// mô tả nhóm khách hàng
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ngày thành lâp
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người thành lập
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// ngày sử đổi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa đổi
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }


}

using System;
using System.Data;
using System.Data.Common;
using mothernaturesfarm.web.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace mothernaturesfarm.web.DataAccess
{
    public class MNFData
    {
        public bool MemberExists(string emailAddress)
        {
            string sql = "SELECT Count(*) FROM dbo.mnf_Member WHERE EmailAddress=@EmailAddress";

            Database db = DatabaseFactory.CreateDatabase(MNFConfiguration.DBConnectionStringKey);
            DbCommand dbCmd = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCmd, "@EmailAddress", DbType.String, emailAddress);

            return (Convert.ToBoolean(db.ExecuteScalar(dbCmd)));
        }
        public int InsertMember(Member mbr)
        {
            string sql = "INSERT INTO dbo.mnf_Member (EmailAddress, Password, FirstName, LastName, " +
                         "Address1, Address2, City, State, PostalCode, IsEnabled, NewsletterSubscriber, RecommendedBy, DateCreated) " +
                         "VALUES (@EmailAddress, @Password, @FirstName, @LastName, @Address1, @Address2, @City, " +
                         "@State, @PostalCode, @Isenabled, @NewsletterSubscriber, @RecommendedBy, @DateCreated) " +
                         "SELECT @MemberId = SCOPE_IDENTITY()";

            Database db = DatabaseFactory.CreateDatabase(MNFConfiguration.DBConnectionStringKey);
            DbCommand dbCmd = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCmd, "@EmailAddress", DbType.String, mbr.EmailAddress);
            db.AddInParameter(dbCmd, "@Password", DbType.String, mbr.Password);
            db.AddInParameter(dbCmd, "@FirstName", DbType.String, mbr.FirstName);
            db.AddInParameter(dbCmd, "@LastName", DbType.String, mbr.LastName);
            db.AddInParameter(dbCmd, "@Address1", DbType.String, mbr.Address1);
            db.AddInParameter(dbCmd, "@Address2", DbType.String, mbr.Address2);
            db.AddInParameter(dbCmd, "@City", DbType.String, mbr.City);
            db.AddInParameter(dbCmd, "@State", DbType.String, mbr.State);
            db.AddInParameter(dbCmd, "@PostalCode", DbType.String, mbr.PostalCode);
            db.AddInParameter(dbCmd, "@IsEnabled", DbType.Boolean, mbr.IsEnabled);
            db.AddInParameter(dbCmd, "@NewsletterSubscriber", DbType.Boolean, mbr.NewsletterSubscriber);
            db.AddInParameter(dbCmd, "@RecommendedBy", DbType.String, mbr.RecommendedBy);
            db.AddInParameter(dbCmd, "@DateCreated", DbType.DateTime, mbr.DateCreated);

            db.AddOutParameter(dbCmd, "@MemberId", DbType.Int32, 32);

            db.ExecuteNonQuery(dbCmd);
            mbr.MemberId = Convert.ToInt32(db.GetParameterValue(dbCmd, "@MemberId"));
            return (mbr.MemberId);
        }
        public Member FindMember(string emailAddress)
        {
            Member mbr = null;
            string sql = "SELECT MemberId, FirstName, LastName, EmailAddress, Password, Address1, Address2, " +
                         "City, State, PostalCode, IsEnabled, NewsletterSubscriber, RecommendedBy, DateCreated " +
                         "FROM dbo.mnf_Member WHERE EmailAddress=@EmailAddress";

            Database db = DatabaseFactory.CreateDatabase(MNFConfiguration.DBConnectionStringKey);
            DbCommand dbCmd = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCmd, "@EmailAddress", DbType.String, emailAddress);

            using (IDataReader reader = db.ExecuteReader(dbCmd))
            {
                if (reader.Read())
                    mbr = BuildMember(reader);
            }
            return (mbr);
        }
        public Member FindMember(int memberId)
        {
            Member mbr = null;
            string sql = "SELECT MemberId, FirstName, LastName, EmailAddress, Password, Address1, Address2, " +
                         "City, State, PostalCode, IsEnabled, NewsletterSubscriber, RecommendedBy, DateCreated " +
                         "FROM dbo.mnf_Member WHERE MemberId=@MemberId";

            Database db = DatabaseFactory.CreateDatabase(MNFConfiguration.DBConnectionStringKey);
            DbCommand dbCmd = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCmd, "@MemberId", DbType.Int32, memberId);

            using (IDataReader reader = db.ExecuteReader(dbCmd))
            {
                if (reader.Read())
                    mbr = BuildMember(reader);
            }
            return (mbr);
        }
        public void UpdateMember(Member mbr)
        {
            string sql = "UPDATE dbo.mnf_member SET " +
                         "FirstName=@FirstName, LastName=@LastName, Address1=@Address1, Address2=@Address2, " +
                         "City=@City, State=@State, PostalCode=@PostalCode, RecommendedBy=@RecommendedBy " +
                         "WHERE MemberId=@MemberId";

            Database db = DatabaseFactory.CreateDatabase(MNFConfiguration.DBConnectionStringKey);
            DbCommand dbCmd = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCmd, "@MemberId", DbType.Int32, mbr.MemberId);
            db.AddInParameter(dbCmd, "@FirstName", DbType.String, mbr.FirstName);
            db.AddInParameter(dbCmd, "@LastName", DbType.String, mbr.LastName);
            db.AddInParameter(dbCmd, "@Address1", DbType.String, mbr.Address1);
            db.AddInParameter(dbCmd, "@Address2", DbType.String, mbr.Address2);
            db.AddInParameter(dbCmd, "@City", DbType.String, mbr.City);
            db.AddInParameter(dbCmd, "@State", DbType.String, mbr.State);
            db.AddInParameter(dbCmd, "@PostalCode", DbType.String, mbr.PostalCode);
            db.AddInParameter(dbCmd, "@RecommendedBy", DbType.String, mbr.RecommendedBy);

            db.ExecuteNonQuery(dbCmd);
        }
        private Member BuildMember(IDataReader reader)
        {
            Member mbr = new Member();
            mbr.MemberId = Convert.ToInt32(reader["MemberId"]);
            mbr.FirstName = reader["FirstName"].ToString();
            mbr.LastName = reader["LastName"].ToString();
            mbr.EmailAddress = reader["EmailAddress"].ToString();
            mbr.Password = reader["Password"].ToString();
            mbr.Address1 = reader["Address1"].ToString();
            mbr.Address2 = reader["Address2"].ToString();
            mbr.City = reader["City"].ToString();
            mbr.State = reader["State"].ToString();
            mbr.PostalCode = reader["PostalCode"].ToString();
            mbr.NewsletterSubscriber = Convert.ToBoolean(reader["NewsletterSubscriber"]);
            mbr.IsEnabled = Convert.ToBoolean(reader["IsEnabled"]);
            mbr.RecommendedBy = reader["RecommendedBy"].ToString();
            mbr.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
            return (mbr);
        }
        public int InsertCoupon(Coupon coupon)
        {
            string sql = "INSERT INTO dbo.mnf_Coupon (Name, Description, IsEnabled, DateCreated) " +
                         "VALUES (@Name, @Description, @IsEnabled, @DateCreated) " +
                         "SELECT @CouponId = SCOPE_IDENTITY()";

            Database db = DatabaseFactory.CreateDatabase(MNFConfiguration.DBConnectionStringKey);
            DbCommand dbCmd = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCmd, "@Name", DbType.String, coupon.Name);
            db.AddInParameter(dbCmd, "@Description", DbType.String, coupon.Description);
            db.AddInParameter(dbCmd, "@IsEnabled", DbType.Boolean, coupon.IsEnabled);
            db.AddInParameter(dbCmd, "@DateCreated", DbType.DateTime, coupon.DateCreated);

            db.AddOutParameter(dbCmd, "@CouponId", DbType.Int32, 32);

            db.ExecuteNonQuery(dbCmd);
            coupon.CouponId = Convert.ToInt32(db.GetParameterValue(dbCmd, "@CouponId"));
            return (coupon.CouponId);
        }
        public bool CouponIsEnabled(int couponId)
        {
            string sql = "SELECT IsEnabled FROM dbo.mnf_Coupon WHERE CouponId=@CouponId";

            Database db = DatabaseFactory.CreateDatabase(MNFConfiguration.DBConnectionStringKey);
            DbCommand dbCmd = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCmd, "@CouponId", DbType.String, couponId);

            return (Convert.ToBoolean(db.ExecuteScalar(dbCmd)));
        }
        public int InsertCouponMemberUsage(CouponMemberUsage cmu)
        {
            string sql = "INSERT INTO dbo.mnf_CouponMemberUsage (CouponId, MemberId, DateUsed) " +
                         "VALUES (@CouponId, @MemberId, @DateUsed) " +
                         "SELECT @CouponMemberUsageId = SCOPE_IDENTITY()";

            Database db = DatabaseFactory.CreateDatabase(MNFConfiguration.DBConnectionStringKey);
            DbCommand dbCmd = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCmd, "@CouponId", DbType.Int32, cmu.CouponId);
            db.AddInParameter(dbCmd, "@MemberId", DbType.Int32, cmu.MemberId);
            db.AddInParameter(dbCmd, "@DateUsed", DbType.DateTime, cmu.DateUsed);

            db.AddOutParameter(dbCmd, "@CouponMemberUsageId", DbType.Int32, 32);

            db.ExecuteNonQuery(dbCmd);
            cmu.CouponMemberUsageId = Convert.ToInt32(db.GetParameterValue(dbCmd, "@CouponMemberUsageId"));
            return (cmu.CouponMemberUsageId);
        }
    }
}
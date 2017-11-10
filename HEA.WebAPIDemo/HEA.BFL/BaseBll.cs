using System.Collections.Generic;
using System.Linq;
using Dapper;
using JCE.Dapper;
using JCE.Dapper.DbModel;
using JCE.Dapper.ExModel;
using JCE.Dapper.Sql;

namespace HEA.BFL
{
	/// <summary>
	/// 业务逻辑层基类
	/// </summary>
	public class BaseBll {
		/// <summary>
		/// 创建数据连接
		/// </summary>
		/// <returns>数据库连接</returns>
		public DbBase CreateDbBase() {
			return new DbBase("sqlServer");
		}
		/// <summary>
		/// 获取查询对象
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <returns>查询对象</returns>
		public SqlQuery<T> GetQuery<T>() where T : class {
			using (var db = CreateDbBase()) {
				return SqlQuery<T>.Builder(db);
			}
		}

		/// <summary>
		/// 新增一条数据
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="model">实体</param>
		/// <returns>bool</returns>
		public bool Add<T>(T model) where T : class {
			using (var db = CreateDbBase()) {
				return db.Insert(model);
			}
		}
		/// <summary>
		/// 新增批量数据
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">列表</param>
		/// <returns>bool</returns>
		public bool AddBatch<T>(IList<T> list) where T : class {
			using (var db = CreateDbBase()) {
				return db.InsertBatch(list);
			}
		}
		/// <summary>
		/// 修改数据
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="model">实体</param>
		/// <param name="sql">查询对象</param>
		/// <returns>bool</returns>
		public bool Update<T>(T model, SqlQuery sql = null) where T : class {
			using (var db = CreateDbBase()) {
				return db.Update(model, sql);
			}
		}
		/// <summary>
		/// 批量修改数据
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="param"></param>
		/// <param name="sql"></param>
		/// <returns></returns>
		public bool UpdateBatch<T>(T list, IList<string> param, SqlQuery sql = null) where T : class {
			using (var db = CreateDbBase()) {
				return db.UpdateBatch(list, param, sql);
			}
		}
		/// <summary>
		/// 删除数据
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="sql">查询对象</param>
		/// <returns>bool</returns>
		public bool Delete<T>(SqlQuery sql = null) where T : class {
			using (var db = CreateDbBase()) {
				return db.Delete<T>(sql);
			}
		}

		/// <summary>
		/// 条件查询
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="sql">查询对象</param>
		/// <returns>结果</returns>
		public IList<T> Query<T>(SqlQuery sql = null) where T : class {
			using (var db = CreateDbBase()) {
				return db.Query<T>(sql);
			}
		}
		/// <summary>
		/// 条件查询-扩展
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sql"></param>
		/// <returns></returns>
		public List<T> QueryEx<T>(string sql) where T : class {
			using (var conn = DbUtils.OpenConnection()) {
				return conn.Query<T>(sql).ToList<T>();
			}
		}
		/// <summary>
		/// 分页查询
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="pageIndex">当前页</param>
		/// <param name="pageSize">记录数</param>
		/// <param name="dataCount">总记录数</param>
		/// <param name="sql">查询对象</param>
		/// <returns>结果</returns>
		public IList<T> PageQuery<T>(int pageIndex, int pageSize, out long dataCount, SqlQuery sql = null) where T : class {
			using (var db = CreateDbBase()) {
				long dc = 0;
				var result = db.PageList<T>(pageIndex, pageSize, out dc, sql);
				dataCount = dc;
				return result;
			}
		}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="sql">查询对象</param>
		/// <returns>bool</returns>
		public bool Exists<T>(SqlQuery sql) where T : class {
			using (var db = CreateDbBase()) {
				return db.Query<T>(sql).Count == 1;
			}
		}
		/// <summary>
		/// 获取一个实体对象
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="sql">查询对象</param>
		/// <returns>实体对象</returns>
		public T GetModel<T>(SqlQuery sql) where T : class {
			using (var db = CreateDbBase()) {
				return db.SingleOrDefault<T>(sql);
			}
		}
		/// <summary>
		/// 获取总记录数
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="sql">查询对象</param>
		/// <returns>实体对象</returns>
		public long Count<T>(SqlQuery sql = null) where T : class {
			using (var db = CreateDbBase()) {
				return db.Count<T>(sql);
			}
		}
		/// <summary>
		/// 获取最大记录数
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="sql">查询对象</param>
		/// <returns>最大记录ID</returns>
		public long MaxId<T>(SqlQuery sql = null) where T : class {
			using (var db = CreateDbBase()) {
				return db.MaxId<T>(sql);
			}
		}
		/// <summary>
		/// 生成查询语句-扩展
		/// </summary>
		/// <param name="param">对象参数</param>
		/// <param name="isPage">是否分页</param>
		/// <returns>查询语句</returns>
		public string GenerateQuerySqlEx(DbParam param, bool isPage = false) {
			return new DbUtils().GenerateQuerySql(param, isPage);
		}
	}
}
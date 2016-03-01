using Datalus.Data;
using Datalus.Web.Domain;
using Datalus.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Datalus.Web.Services
{
    public class EducationsService: BaseService
    {
        public static int AddEducations (EducationsAddRequest Educations)
        {
            int id = 0;
            string UserProfileId = UserService.GetCurrentUserId();

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Educations_Insert"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                { 
                    paramCollection.AddWithValue("@StartDate", Educations.StartDate);
                    paramCollection.AddWithValue("@EndDate", Educations.EndDate);
                    paramCollection.AddWithValue("@SchoolName", Educations.SchoolName);
                    paramCollection.AddWithValue("@Major", Educations.Major);
                    paramCollection.AddWithValue("@Degree", Educations.Degree);
                    paramCollection.AddWithValue("@UserProfileId", Educations.UserProfileId);

                    SqlParameter newIdParameter = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    newIdParameter.Direction = System.Data.ParameterDirection.Output;

                    paramCollection.Add(newIdParameter);

                }, returnParameters: delegate (SqlParameterCollection param)
                {
                    int.TryParse(param["@id"].Value.ToString(), out id);
                }
                );
            return id;
        }

        public static void UpdateEducations(EducationsUpdateRequest Educations)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Educations_Update"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@StartDate", Educations.StartDate);
                    paramCollection.AddWithValue("@EndDate", Educations.EndDate);
                    paramCollection.AddWithValue("@SchoolName", Educations.SchoolName);
                    paramCollection.AddWithValue("@Major", Educations.Major);
                    paramCollection.AddWithValue("@Degree", Educations.Degree);
                    paramCollection.AddWithValue("@UserProfileId", Educations.UserProfileId);
                    paramCollection.AddWithValue("@Id", Educations.Id);
                }, returnParameters: null
                );
        }

        public static Educations GetEducation(int id)
        {
            Educations model = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Educations_SelectById"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@id", id);
               }, map: delegate (IDataReader reader, short set)
               {
                   model = MapEducations(reader);
               }
                   );
            return model;
        }

        public static List<Educations> GetAllEducations()
        {
            List<Educations> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Educations_SelectAll"
               , inputParamMapper: null
               , map: delegate (IDataReader reader, short set)
               {
                   Educations education = MapEducations(reader);

                   if (list == null)
                   {
                       list = new List<Educations>();
                   }

                   list.Add(education);
               }
               );
            return list;
        }

        public static void DeleteEducations(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Educations_Delete"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", id);
               }, returnParameters: null);

        }

        private static Educations MapEducations(IDataReader reader)
        {
            Educations model = new Educations();
            int startingIndex = 0;

            model.Id = reader.GetSafeInt32(startingIndex++);
            model.StartDate = reader.GetDateTime(startingIndex++);
            model.EndDate = reader.GetDateTime(startingIndex++);
            model.SchoolName = reader.GetSafeString(startingIndex++);
            model.Major = reader.GetSafeString(startingIndex++);
            model.Degree = reader.GetSafeString(startingIndex++);

            return model;
        }



    }
}

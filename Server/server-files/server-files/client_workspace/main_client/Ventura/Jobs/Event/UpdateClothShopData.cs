using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using main_client.Ventura.Constant;
using main_client.Ventura.Jobs.ListJobs;
using main_client.Ventura.Jobs.JobsData;
//using Newtonsoft.Json;

namespace main_client.Ventura.Jobs.ListJobs
{
    class UpdateClothShopData : Events.Script
    {
        Constant.Constant.UpdateJobsClient Type = Constant.Constant.UpdateJobsClient.UpdateListClothShopData;
        object list = null;

        public UpdateClothShopData()
        {
            Events.Add(Constant.Constant.table_jobs_data[(int)Type], UpdateListData);
            Events.Tick += Tick;
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {
            if (list == null)
                return;
            var ptr = Constant.Constant.Cast(list, Constant.Constant.table_jobs_type[(int)Type]);
            ptr.Draw();
        }

        private void UpdateListData(object[] args)
        {
            string json = args[0].ToString();
            /*var data = JsonConvert.DeserializeObject(json);

            if (data == null)
                return;
            dynamic tmp = Constant.Constant.Cast(data, Constant.Constant.table_jobs_type[(int)Type]);
            list = new ListClothShopData() { list = tmp };*/
        }
    }
}

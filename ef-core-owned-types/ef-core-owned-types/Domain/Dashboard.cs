using System.Collections.Generic;
using ef_core_owned_types.Infrastructure;

namespace ef_core_owned_types.Domain
{
    public class Dashboard : Entity
    {
        public Dashboard()
        {
            DashboardItems = new List<DashboardItem>();
        }

        public string Name { get; private set; }
        public List<DashboardItem> DashboardItems { get; private set; }

        public Dashboard(string name, List<DashboardItem> dashboardItems)
        {
            Name = name;
            DashboardItems = dashboardItems;
        }

        public void Update(string name, List<DashboardItem> dashboardItems)
        {
            Name = name;
            DashboardItems = dashboardItems;
        }
    }
}
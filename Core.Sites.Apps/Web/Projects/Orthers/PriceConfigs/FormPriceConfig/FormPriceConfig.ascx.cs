using Core.Business.Entities;
using Core.Business.Entities.Others.PriceConfigs;
using Core.Extensions;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using System.Collections.Generic;
using System.Linq;
using Core.Web.Extensions;
using Aspose.Cells;

namespace Core.Sites.Apps.Web.Projects.Orthers.PriceConfigs.FormPriceConfig
{
    [Script(Src = "/Web/Projects/Orthers/PriceConfigs/FormPriceConfig/js/FormPriceConfig.js")]
    [Module]
    [ManageModulePermission(Edit = Per.P_51002)]
    public partial class FormPriceConfig : PortalModule<PriceConfig>
    {
        protected override void OnInitData()
        {
            var priceConfigs = new PriceConfig.DataSource { }.GetEntities();
            var directions = new Direction.DataSource { LanguageId = 2, Start = 0, Length = int.MaxValue, FieldOrder = "CreatedDate", Dir = "ASC" }.GetEntities();
            var startpoints = directions.Where(d => d.IsStart);
            var endpoints = directions.Where(d => d.IsEnd);
            var productTypes = new ProductType.DataSource { LanguageId = 2, Start = 0, Length = int.MaxValue, FieldOrder = "CreatedDate", Dir = "ASC" }.GetEntities();

            var outPriceConfigs = new List<PriceConfig>();
            startpoints.ForEach(start =>
            {
                endpoints.ForEach(end =>
                {
                    productTypes.ForEach(type =>
                    {
                        for (int i = 1; i <=2; i++)
                        {
                            PriceConfig config = new PriceConfig();
                            config.StartDirection = start.DirectionId;
                            config.EndDirection = end.DirectionId;
                            config.StartPointName = start.DirectionName;
                            config.EndPointName = end.DirectionName;
                            config.ProductType = type.TypeId;
                            config.ProductTypeName = type.ProductTypeName;
                            if (i == 1)
                            {
                                config.ContainerType = TranType.C20T;
                                config.TranTypeName = "Container 20T";
                                var currentPrice = priceConfigs.FirstOrDefault(price => 
                                price.StartDirection == start.DirectionId
                                && price.EndDirection == end.DirectionId
                                && price.ProductType == type.TypeId
                                && price.ContainerType == TranType.C20T);
                                config.Price = currentPrice == null ? 0 : currentPrice.Price;

                                outPriceConfigs.Add(config);
                            }
                            else if(i == 2)
                            {
                                config.ContainerType = TranType.C40T;
                                config.TranTypeName = "Container 40T";
                                var currentPrice = priceConfigs.FirstOrDefault(price => price.StartDirection == start.DirectionId
                                && price.EndDirection == end.DirectionId
                                && price.ProductType == type.TypeId
                                && price.ContainerType == TranType.C40T);
                                config.Price = currentPrice == null ? 0 : currentPrice.Price;

                                outPriceConfigs.Add(config);
                            }
                        };
                    });
                });
            });
            rpConfigs.DoBind(outPriceConfigs);
        }
        public void SaveAllData(List<PriceConfig> ResData)
        {
            var Datasave = new List<PriceConfig>();
            var oldConfigs = new PriceConfig.DataSource { }.GetEntities();

            ResData.ForEach(res =>
            {
                var currentData = oldConfigs.FirstOrDefault(price => price.StartDirection == res.StartDirection
                                && price.EndDirection == res.EndDirection
                                && price.ProductType == res.ProductType
                                && price.ContainerType == res.ContainerType);
                if(currentData != null && currentData.Price != res.Price)
                {
                    currentData.Price = res.Price;
                    Datasave.Add(currentData);
                }
                else if(currentData == null)
                {
                    Datasave.Add(res);
                }
            });

            Datasave.ForEach(c => { c.Upsert(); });
        }
    }
}
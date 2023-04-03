using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data;
using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Facade
{
    public abstract class ViewFactoryTests<TFactory, TView, TObj, TData>
      : SealedClassTests<TFactory, BaseViewFactory<TView, TObj, TData>>
      where TFactory : BaseViewFactory<TView, TObj, TData>, new()
      where TView : class, new()
      where TData : UniqueData, new()
      where TObj : UniqueEntity<TData>
    {
        [TestMethod] public virtual void CreateTest() { }
        [TestMethod]
        public virtual void CreateViewTest()
        {
            var v = GetRandom.Value<TView>();
            var o = obj.Create(v);
            areEqualProperties(v, o.Data);
        }
        [TestMethod]
        public void CreateObjectTest()
        {
            var d = GetRandom.Value<TData>();
            var v = obj.Create(toObject(d));
            areEqualProperties(d, v);
        }
        protected abstract TObj toObject(TData d);
    }
}

﻿using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Pure.DI;
using ZenIoc;
using static Pure.DI.Lifetime;

namespace IocPerformance.Adapters
{
    public sealed class PureDiAdapter : ContainerAdapterBase
    {
        static PureDiAdapter()
        {
            DI.Setup("Composer")
                .TagAttribute<ResolveNamedAttribute>()
                .Bind<CompositionRoot>().To<CompositionRoot>()

                .Bind<IDummyOne>().To<DummyOne>()
                .Bind<IDummyTwo>().To<DummyTwo>()
                .Bind<IDummyThree>().To<DummyThree>()
                .Bind<IDummyFour>().To<DummyFour>()
                .Bind<IDummyFive>().To<DummyFive>()
                .Bind<IDummySix>().To<DummySix>()
                .Bind<IDummySeven>().To<DummySeven>()
                .Bind<IDummyEight>().To<DummyEight>()
                .Bind<IDummyNine>().To<DummyNine>()
                .Bind<IDummyTen>().To<DummyTen>()

                .Bind<ISingleton1>().As(Singleton).To<Singleton1>()
                .Bind<ISingleton2>().As(Singleton).To<Singleton2>()
                .Bind<ISingleton3>().As(Singleton).To<Singleton3>()
                .Bind<ITransient1>().To<Transient1>()
                .Bind<ITransient2>().To<Transient2>()
                .Bind<ITransient3>().To<Transient3>()
                .Bind<ICombined1>().To<Combined1>()
                .Bind<ICombined2>().To<Combined2>()
                .Bind<ICombined3>().To<Combined3>()

                .Bind<IFirstService>().As(Singleton).To<FirstService>()
                .Bind<ISecondService>().As(Singleton).To<SecondService>()
                .Bind<IThirdService>().As(Singleton).To<ThirdService>()
                .Bind<ISubObjectA>().To<SubObjectA>()
                .Bind<ISubObjectB>().To<SubObjectB>()
                .Bind<ISubObjectC>().To<SubObjectC>()
                .Bind<IComplex1>().To<Complex1>()
                .Bind<IComplex2>().To<Complex2>()
                .Bind<IComplex3>().To<Complex3>()

                .Bind<IComplexPropertyObject1>().To<ComplexPropertyObject1>()
                .Bind<IComplexPropertyObject2>().To<ComplexPropertyObject2>()
                .Bind<IComplexPropertyObject3>().To<ComplexPropertyObject3>()
                .Bind<IServiceA>().As(Singleton).To<ServiceA>()
                .Bind<IServiceB>().As(Singleton).To<ServiceB>()
                .Bind<IServiceC>().As(Singleton).To<ServiceC>()
                .Bind<ISubObjectOne>().To<SubObjectOne>()
                .Bind<ISubObjectTwo>().To<SubObjectTwo>()
                .Bind<ISubObjectThree>().To<SubObjectThree>()

                .Bind<IGenericInterface<TT>>().To<GenericExport<TT>>()
                .Bind<ImportGeneric<TT>>().To<ImportGeneric<TT>>()

                .Bind<ImportConditionObject1>().To<ImportConditionObject1>()
                .Bind<ImportConditionObject2>().To<ImportConditionObject2>()
                .Bind<ImportConditionObject3>().To<ImportConditionObject3>()
                .Bind<IExportConditionInterface>().Tag("ExportConditionalObject1").To<ExportConditionalObject1>()
                .Bind<IExportConditionInterface>().Tag("ExportConditionalObject2").To<ExportConditionalObject2>()
                .Bind<IExportConditionInterface>().Tag("ExportConditionalObject3").To<ExportConditionalObject3>()

                .Bind<ISimpleAdapter>().To<SimpleAdapterOne>()
                .Bind<ISimpleAdapter>().Tag(2).To<SimpleAdapterTwo>()
                .Bind<ISimpleAdapter>().Tag(3).To<SimpleAdapterThree>()
                .Bind<ISimpleAdapter>().Tag(4).To<SimpleAdapterFour>()
                .Bind<ISimpleAdapter>().Tag(5).To<SimpleAdapterFive>()
                .Bind<ImportMultiple1>().To<ImportMultiple1>()
                .Bind<ImportMultiple2>().To<ImportMultiple2>()
                .Bind<ImportMultiple3>().To<ImportMultiple3>();
        }

        public override string PackageName => "Pure.DI";

        public override string Url => "https://github.com/DevTeam/Pure.DI";

        public override bool SupportsPropertyInjection => true;

        public override bool SupportGeneric => true;

        public override bool SupportsConditional => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPrepareAndRegister => false;

        public override object Resolve(Type type) => Composer.Resolve(type);

        public override void Dispose() { }

        public override void PrepareBasic() { }

        public override void Prepare() { }

        internal class CompositionRoot
        {
            public CompositionRoot(ImportGeneric<int> val1, ImportGeneric<float> val2, ImportGeneric<object> val3) { }
        }
    }
}
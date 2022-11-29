namespace DependencyIjectionLifeCycle.Models
{
    public interface IGuidGenerator
    {
        Guid Guid { get; }
    }

    public interface IScopedGuidGenerator : IGuidGenerator
    {

    }

    public interface ITransientGuidGenerator : IGuidGenerator
    {

    }
    public interface ISingletonGuidGenerator : IGuidGenerator
    {

    }


    public class ScopedGuidGenerator : IScopedGuidGenerator
    {
        public ScopedGuidGenerator()
        {
            this.Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }

    public class SingletonGuidGenerator : ISingletonGuidGenerator
    {
        public SingletonGuidGenerator()
        {
            this.Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }

    public class TransientGuidGenerator : ITransientGuidGenerator
    {
        public TransientGuidGenerator()
        {
            this.Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }

    public class GuidService
    {
        public readonly ITransientGuidGenerator _transient;
        public readonly IScopedGuidGenerator _scoped;
        public readonly ISingletonGuidGenerator _singleton;

        public GuidService(ITransientGuidGenerator transient, IScopedGuidGenerator scoped, ISingletonGuidGenerator singleton)
        {
            _transient = transient;
            _scoped = scoped;
            _singleton = singleton;
        }
    }

}

using System;

namespace WhatsNewInCSharp9
{
	public record PipelineConfiguration(Guid Id);

	public class Pipeline
	{
		protected Guid id;

		public virtual Pipeline AddIdentifier(Guid id)
		{
			this.id = id;
			return this;
		}

		public virtual PipelineConfiguration GetConfiguration() => 
			new PipelineConfiguration(this.id);
	}

	public record CustomPipelineConfiguration(Guid Id, string? Name)
		: PipelineConfiguration(Id);

	public class CustomPipeline
		: Pipeline
	{
		private string? name;

		public CustomPipeline AddName(string name)
		{
			this.name = name;
			return this;
		}

		public override CustomPipeline AddIdentifier(Guid id)
		{
			this.id = id;
			return this;
		}

		public override CustomPipelineConfiguration GetConfiguration() => 
			new CustomPipelineConfiguration(this.id, this.name);
	}
}
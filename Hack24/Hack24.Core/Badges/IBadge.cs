using Hack24.Core.Entities;

namespace Hack24.Core.Badges
{
	public interface IBadge
	{
		string Name { get; }
		string Description { get; }
		bool IsEligible(User user);
	}
}
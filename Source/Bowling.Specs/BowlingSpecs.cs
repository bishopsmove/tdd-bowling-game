using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	class when_rolling_all_gutter_balls : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			20.times(() => _game.Roll(0) );
		}

		[Specification]
		public void the_score_should_be_zero()
		{
			_game.Score.should_equal(0);
		}
	}

	class when_rolling_all_ones : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			20.times(() => _game.Roll(1));
		}

		[Specification]
		public void the_score_should_be_twenty()
		{
			_game.Score.should_equal(20);
		}
	}
}
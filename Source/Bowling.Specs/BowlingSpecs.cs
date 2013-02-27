using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class when_rolling_all_gutters : concerns
	{
	    private int _score;

	    protected override void context()
		{
		    var game = new Game();
            20.times(()=> game.Roll(0));

		    _score = game.Score();
		}

		[Specification]
		public void the_score_is_zero()
		{
		    _score.should_equal(0);
		}
	}

    public class when_rolling_open_frame : concerns
    {
        private int _score;

        protected override void context()
        {
            var game = new Game();
            20.times(() => game.Roll(2));
            _score = game.Score();
        }

        [Specification]
        public void the_score_is_zero()
        {
            _score.should_equal(40);
        }
    }

    public class when_rolling_spare_frame : concerns
    {
        private int _score;

        protected override void context()
        {
            var game = new Game();

            game.Roll(2);
            game.Roll(8);

            18.times(() => game.Roll(2));
            _score = game.Score();
        }

        [Specification]
        public void the_score_is_48()
        {
            _score.should_equal(48);
        }

    }
    public class when_rolling_2_spare_frames : concerns
    {
        private int _score;

        protected override void context()
        {
            var game = new Game();

            game.Roll(2);
            game.Roll(8);
            game.Roll(2);
            game.Roll(8);

            16.times(() => game.Roll(2));
            _score = game.Score();
        }

        [Specification]
        public void the_score_is_56()
        {
            _score.should_equal(56);
        }

    }

    public class when_rolling_11th_frame : concerns
    {
        private bool _canBowl;

        protected override void context()
        {
            var game = new Game();
            20.times(() => game.Roll(2));
            _canBowl = game.CanBowl();
            
        }

        [Specification]
        public void cannot_bowl_more()
        {
            _canBowl.should_be_false();
        }
    }

    public class when_rolling_strike_frame : concerns
    {
        private int _score;

        protected override void context()
        {
            var game = new Game();

            game.Roll(10);
            18.times(() => game.Roll(2));
            _score = game.Score();
        }

        [Specification]
        public void the_score_is_50()
        {
            _score.should_equal(50);
        }

    }

    public class when_rolling_2_strike_frames : concerns
    {
        private int _score;

        protected override void context()
        {
            var game = new Game();

            game.Roll(10);
            game.Roll(10);
            16.times(() => game.Roll(2));
            _score = game.Score();
        }

        [Specification]
        public void the_score_is_68()
        {
            _score.should_equal(68);
        }

    }

    public class when_rolling_perfect_game : concerns
    {
        private int _score;

        protected override void context()
        {
            var game = new Game();

            
            12.times(() => game.Roll(10));
            _score = game.Score();
        }

        [Specification]
        public void the_score_is_300()
        {
            _score.should_equal(300);
        }

    }
}
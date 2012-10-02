﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bowling.Specs;

namespace Bowling
{
	public class Frame
	{
	    private List<Roll> _rolls;
	    public Frame()
	    {
	        _rolls = new List<Roll>();
	    }

		public void AddRoll(Roll roll)
		{
			if(CheckMaxAllowedRollRule())
				_rolls.Add(roll);
			else
				throw new MaxAllowedRollsExceededException();

			if(roll.Pins==10 && _rolls.Count==1)
			{
				IsStrike = true;
				IsComplete = true;
			}
			else if(_rolls.Count==2)
			{
				IsComplete = true;
				{
					if(_rolls.Sum(r => r.Pins) == 10)
					{
						IsSpare = true;
					}
				}
			}
		}

		public bool IsComplete { get; private set; }

		public IEnumerable<Roll> Rolls
		{
			get { return _rolls; }
		}

		private bool CheckMaxAllowedRollRule()
		{
			return _rolls.Count < 2;
		}

		public bool IsSpare { get; private set; }

		public bool IsStrike { get; private set; }

	}
}

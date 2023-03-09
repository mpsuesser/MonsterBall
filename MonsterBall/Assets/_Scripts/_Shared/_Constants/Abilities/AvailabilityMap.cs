using System.Collections.Generic;

namespace MonsterBall.Constants.Abilities
{
    public static class AvailabilityMap
    {
        /**
         * Desired: map[MonsterType][PlayStateType][TeamSideType]
         */
        public static
            Dictionary<MonsterType, Dictionary<PlayStateType,
                Dictionary<TeamSideType, HashSet<AbilityType>>>> Defaults =
                new Dictionary<MonsterType, Dictionary<PlayStateType,
                    Dictionary<TeamSideType, HashSet<AbilityType>>>>()
                {
                    /**
                     * public enum AbilityType
                        {
                           Move = 0,
                           Stop,
                           Charge,
                           Hike,
                           Throw,
                           Tackle,
                           Stiff,
                           Juke,
                           FakeMarker,
                        }
                     */
                    [MonsterType.Quarterback] =
                    {
                        [PlayStateType.PreSnap] =
                        {
                            [TeamSideType.Offense] =
                            {
                                AbilityType.Move,
                                AbilityType.Stop,
                                AbilityType.Hike,
                            },
                            [TeamSideType.Defense] =
                            {
                                
                            }
                        },
                        [PlayStateType.MidPlay] =
                        {
                            [TeamSideType.Offense] =
                            {
                                    AbilityType.Move,
                                    AbilityType.Stop,
                                    AbilityType.Charge,
                                    AbilityType.Throw,
                                    AbilityType.Tackle,
                                    AbilityType.Stiff,
                                    AbilityType.Juke,
                                    AbilityType.FakeMarker,
                            },
                            [TeamSideType.Defense] =
                            {
                                
                            }
                        },
                        [PlayStateType.PostPlay] =
                        {
                            [TeamSideType.Offense] =
                            {
                                AbilityType.Move,
                                AbilityType.Stop,
                                AbilityType.Charge,
                                AbilityType.Tackle,
                                AbilityType.Stiff,
                                AbilityType.Juke,
                            },
                            [TeamSideType.Defense] =
                            {
                                
                            }
                        }
                    }
                };
    }
}

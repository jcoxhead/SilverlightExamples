using System;
using KarelRobotCore.Enums;
using KarelRobotCore.Interfaces;
using KarelTheRobotLib.DTO;
using KarelTheRobotLib.Exceptions;

namespace KarelTheRobotLib
{
    public class Robot : IRobot
    {
        #region Private Fields

        private int _street;
        private IWorld _world;

        private readonly LocationPoint _location;

        #endregion

        #region Public Constructors

        public Robot()
        {
            _location = new LocationPoint(1, 1);
            Direction = Direction.North;
        }

        public Robot(IWorld world)
        {
            _location = new LocationPoint(1, 1);
            Direction = Direction.North;

            _world = world;
        }

        #endregion

        #region Public Accessors

        public IWorld World
        {
            get
            {
                return _world;
            }
            set
            {
                _world = value;
                _location.Avenue = _world.RobotStartAvenue;
                _location.Street = _world.RobotStartStreet;
                Beepers = _world.RobotStartBeepers;
                Direction = _world.RobotStartDirection;
            }
        }

        public int Beepers
        {
            get;
            set;
        }

        public Direction Direction
        {
            get;
            set;
        }

        public int Street
        {
            get
            {
                return _location.Street;
            }
            set
            {
                _location.Street = value;
            }
        }

        public int Avenue
        {
            get
            {
                return _location.Avenue;
            }
            set
            {
                _location.Avenue = value;
            }
        }

        #endregion

        #region Manouvre Robot

        public void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.West;
                    break;
                case Direction.East:
                    Direction = Direction.North;
                    break;
                case Direction.South:
                    Direction = Direction.East;
                    break;
                case Direction.West:
                    Direction = Direction.South;
                    break;
            }
        }

        public void TurnRight()
        {
            TurnLeft();
            TurnLeft();
            TurnLeft();
        }

        // Turn 180 degress
        public void TurnAround()
        {
            TurnLeft();
            TurnLeft();
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.North:
                    if (!_world.IsInBounds(_location.Avenue,
                                   Street + 1))
                        throw new KarelOutOfBoundsExcception();
                    else if (_world.CheckEastWestWallExists(Avenue,
                                   Street))
                        throw new KarelCrashedException();
                    else
                        Street += 1;
                    break;
                case Direction.East:
                    if (!_world.IsInBounds(Avenue + 1, Street))
                        throw new KarelOutOfBoundsExcception();
                    else if (_world.CheckNorthSouthWallExists(_location.Avenue, _location.Street))
                        throw new KarelCrashedException();
                    else
                        Avenue += 1;
                    break;
                case Direction.South:
                    if (!_world.IsInBounds(Avenue, Street - 1))
                        throw new KarelOutOfBoundsExcception();
                    else if (_world.CheckEastWestWallExists(Avenue, Street - 1))
                        throw new KarelCrashedException();
                    else
                        Street -= 1;
                    break;
                case Direction.West:
                    if (!_world.IsInBounds(Avenue - 1, Street))
                        throw new KarelOutOfBoundsExcception();
                    else if (_world.CheckNorthSouthWallExists(Avenue - 1, Street))
                        throw new KarelCrashedException();
                    else
                        Avenue -= 1;
                    break;
            }
        }

        #endregion

        #region Beeper Members

        public void PickBeeper()
        {
            _world.PickBeeper(_location.Avenue, _location.Street);
            Beepers += 1;
        }

        ///**
        // * TODO: bounds checking on putBeeper!  Is beeper bag empty?
        // */
        public void PutBeeper()
        {
            Beepers -= 1;
            _world.PutBeeper(_location.Avenue, _location.Street);
        }

        public bool NoBeepersPresent()
        {
            return (_world.CheckBeepersExists(Avenue, Street));
        }

        #endregion

        #region Util Methods

        public void Turnoff()
        {
        }

        #endregion

        #region Direction Blocked Members

        public bool IsDirectionBlocked(KarelRobotCore.Enums.Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return _world.CheckEastWestWallExists(_location.Avenue, _location.Street);
                case Direction.East:
                    return _world.CheckNorthSouthWallExists(_location.Avenue, _location.Street);
                case Direction.South:
                    if (_location.Street == 1)
                        return true;
                    else
                        return _world.CheckEastWestWallExists(_location.Avenue, _location.Street - 1);
                case Direction.West:
                    if (_location.Avenue == 1)
                        return true;
                    else
                        return _world.CheckNorthSouthWallExists(_location.Avenue - 1, _location.Street);
                default:
                    throw new ApplicationException("Unknown direction " + Direction);
            }
        }

        #endregion

        #region Facing Members

        public bool FacingEast()
        {
            return (Direction == Direction.East);
        }

        public bool FacingNorth()
        {
            return (Direction == Direction.North);
        }

        public bool FacingSouth()
        {
            return (Direction == Direction.South);
        }

        public bool FacingWest()
        {
            return (Direction == Direction.West);
        }

        public bool NotFacingEast()
        {
            return (!FacingEast());
        }

        public bool NotFacingNorth()
        {
            return (!FacingNorth());
        }

        public bool NotFacingSouth()
        {
            return (!FacingSouth());
        }

        public bool NotFacingWest()
        {
            return (!FacingEast());
        }

        #endregion

        #region Test Front is Blocked

        public bool FrontIsBlocked()
        {
            return IsDirectionBlocked(Direction);
        }

        public bool FrontIsClear()
        {
            return (!IsDirectionBlocked(Direction));
        }

        #endregion

        #region Test Left is Blocked

        public bool LeftIsBlocked()
        {
            switch (Direction)
            {
                case Direction.North:
                    return IsDirectionBlocked(Direction.West);
                case Direction.East:
                    return IsDirectionBlocked(Direction.North);
                case Direction.South:
                    return IsDirectionBlocked(Direction.East);
                case Direction.West:
                    return IsDirectionBlocked(Direction.South);
                default:
                    throw new ApplicationException("Unknown direction " + Direction);
            }
        }

        public bool LeftIsClear()
        {
            return (!LeftIsBlocked());
        }

        #endregion

        #region Test Right is Blocked

        public bool RightIsBlocked()
        {
            switch (Direction)
            {
                case Direction.North:
                    return IsDirectionBlocked(Direction.East);
                case Direction.East:
                    return IsDirectionBlocked(Direction.South);
                case Direction.South:
                    return IsDirectionBlocked(Direction.West);
                case Direction.West:
                    return IsDirectionBlocked(Direction.North);
                default:
                    throw new ApplicationException("Unknown direction " + Direction);
            }
        }

        public bool RightIsClear()
        {
            return (!RightIsBlocked());
        }

        #endregion

        #region Beeper Tests

        public bool AnyBeepersInBeeperBag()
        {
            return (Beepers > 0);
        }

        public bool NextToABeeper()
        {
            return _world.CheckBeepersExists(_location.Avenue, _location.Street);
        }

        public bool NoBeepersInBeeperBag()
        {
            return (Beepers == 0);
        }

        public bool NotNextToABeeper()
        {
            return (!NextToABeeper());
        }

        #endregion

    }
}

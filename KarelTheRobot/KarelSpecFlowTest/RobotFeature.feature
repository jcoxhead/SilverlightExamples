Feature: Addition
	In order to allow robot to move
	As a robot controller
	I want to be able to move robot

@mytag
Scenario: Move robot
	Given I have set up robot to move
	When I ask robot to move
	Then the robot should have moved

Feature: Vehicle search

Scenario: Seasrach for vehicle based on ID
	Given the vehicle ID is: <VehicleID>
	When response status is: OK
	Then the vehicle name is: <VehicleName>
Examples:
	| VehicleID | VehicleName                 |
	| 14        | Snowspeeder                 |
	| 20        | Storm IV Twin-Pod cloud car |
	| 25        | Bantha-II cargo skiff       |
# Fork info
This repository is a fork of https://github.com/Cyanox62/Lone079. It has been created to bind health of spawned SCP with number of activated generators.

# Lone079

SCP-079 will be turned into a random SCP with partial health and spawned in SCP-939s containment chamber when he is the last SCP alive instead of being auto recontained.

# Installation

**[EXILED](https://github.com/galaxy119/EXILED) must be installed for this to work.**

Place the "Lone079.dll" file in your sm_plugins folder.

# Configs

| Config        | Value Type | Default Value | Description |
| :-------------: | :---------: | :------: | :--------- |
| l079_count_zombies | Boolean | False | Determines if zombies should be counted when determining if SCP-079 is the last SCP alive. |
| l079_health_percentage | Integer | 50 | The percentage of normal health SCP-079 should have when he respawns as a random SCP. |
| l079_health_buff_per_level | Integer | 30 | The percentage points added to health_percentage for every SCP-079 level above one. |
| l079_health_loss_per_activated_generator | Integer | 20 | The percentage points subtracted from health_percentage for every activated generator. |
| l079_proportional_health | Boolean | True | If true, health_percentage is multiplied by percent of generators not activated. Therefore, value of health_loss_per_activated_generator is ignored. |


﻿using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lone079
{
	class EventHandlers
	{
		private System.Random rand = new System.Random();

		private Vector3 scp939pos;

		private bool is106Contained, canChange;

		private List<RoleType> scp079Respawns = new List<RoleType>()
		{
			RoleType.Scp049,
			RoleType.Scp096,
			RoleType.Scp106,
			RoleType.Scp93953,
			RoleType.Scp93989
		};

		private List<RoleType> scp079RespawnLocations = new List<RoleType>()
		{
			RoleType.Scp049,
			RoleType.Scp096,
			RoleType.Scp93953
		};

		private IEnumerator<float> Check079(float delay = 1f)
		{
			if (Map.ActivatedGenerators != 5 && canChange)
			{
				yield return Timing.WaitForSeconds(delay);
				IEnumerable<Player> enumerable = Player.List.Where(x => x.Team == Team.SCP);
				if (!Lone079.instance.Config.CountZombies) enumerable = enumerable.Where(x => x.Role != RoleType.Scp0492);
				List<Player> pList = enumerable.ToList();
				if (pList.Count == 1 && pList[0].Role == RoleType.Scp079)
				{
					Player player = pList[0];
					int level = player.Level;
					float healthPercent = Lone079.instance.Config.HealthPercent +
						level * Lone079.instance.Config.HealthBuffPerLevel -
						Map.ActivatedGenerators * Lone079.instance.Config.HealthLossPerActivatedGenerator;
					if (healthPercent > 0)
					{
						RoleType role = scp079Respawns[rand.Next(scp079Respawns.Count)];
						if (is106Contained && role == RoleType.Scp106) role = RoleType.Scp93953;
						player.SetRole(role);
						Timing.CallDelayed(1f, () => player.Position = scp939pos);
						player.Health = player.MaxHealth * (healthPercent / 100f);
						player.Broadcast(10, "<i>You have been respawned as a random SCP with "+ healthPercent + "% health because all other SCPs have died.</i>");
					}
				}
			}
		}

		// no work
		public void OnPlayerLeave(LeftEventArgs ev)
		{
			if (ev.Player.Team == Team.SCP) Timing.RunCoroutine(Check079(3f));
		}

		public void OnDetonated() => canChange = false;

		public void OnRoundStart()
		{
			Timing.CallDelayed(1f, () => scp939pos = GameObject.FindObjectOfType<SpawnpointManager>().GetRandomPosition(scp079RespawnLocations[rand.Next(scp079RespawnLocations.Count)]).transform.position);
			is106Contained = false;
			canChange = true;
		}

		public void OnPlayerDied(DiedEventArgs ev)
		{
			//if (ev.Target.Team == Team.SCP) Timing.RunCoroutine(Check079(3f));
			Timing.RunCoroutine(Check079(3f));
		}

		public void OnScp106Contain(ContainingEventArgs ev)
		{
			is106Contained = true;
		}
	}
}

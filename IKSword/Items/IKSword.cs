using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace IKSword.Items
{
	public class IKSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Insta-Kill Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Insta-Kills ANY boss! For Gameraiders101!");
		}

		public override void SetDefaults() 
		{
			item.damage = 1;
			item.melee = true;
			item.width = 320;
			item.height = 320;
			item.useTime = 2;
			item.useAnimation = 2;
			item.useStyle = 1;
			item.knockBack = 0;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips) 
		{
			tooltips[1] = new TooltipLine(mod, "damageline", "∞ melee damage");
     		tooltips[2] = new TooltipLine(mod, "critline", "∞% critical strike chance");
     		tooltips[3] = new TooltipLine(mod, "spdline", "∞ speed");
			tooltips[4] = new TooltipLine(mod, "kbline", "∞ knockback");
			tooltips[5] = new TooltipLine(mod, "infinityline", "∞ power");
			tooltips[6] = new TooltipLine(mod, "endline", "∞.");

        	tooltips[6].overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
			tooltips[1].overrideColor = new Color(Main.DiscoR, 0, 0);
			tooltips[2].overrideColor = new Color(0, Main.DiscoG, 0);
			tooltips[3].overrideColor = new Color(0, 0, Main.DiscoB);
			tooltips[4].overrideColor = new Color(Main.DiscoR, Main.DiscoG, 0);
			tooltips[5].overrideColor = new Color(0, Main.DiscoG, Main.DiscoB);
		}

		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			target.life = 0;
			target.NPCLoot();
			CombatText.NewText(new Rectangle((int)target.position.X, (int)target.position.Y, 80, 40), Color.Red, "∞", true);
			target.HitEffect();
			Main.PlaySound(target.DeathSound); //(int)target.Center.X, (int)target.Center.Y, 15);
		}
	}
}
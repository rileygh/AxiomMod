using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;

namespace AxiomMod.Items.Weapons
{
    public class ScarletDawn : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scarlet Dawn");
            Tooltip.SetDefault("The sky set aflame.");
        }
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.Cyan;
            Item.damage = 110;
            Item.knockBack = 6;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.shoot = ProjectileID.InfernoFriendlyBlast;
            Item.shootSpeed = 25f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 2;
            float rotation = MathHelper.ToRadians(5);

            for (int i = 0; i < numberProjectiles; i++)
            {
                Single rot = MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1));
                Vector2 perturbedSpeed = velocity.RotatedBy(rot) * .2f;
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            // @todo: add recipe (pre-plantera)
            recipe.AddIngredient(ItemID.MagmaStone, 1); // temp
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}


﻿using System.Collections.Generic;
using UnityEngine;

namespace DuskHaxx
{
    class Aimbot : MonoBehaviour
    {
        class LocalVariables
        {
            public static List<Vector3> enemyPos = new List<Vector3>();
        }

        public void Update()
        {
            if (variables.CheatState.aimbot_bool)
            {
                LocalVariables.enemyPos.Clear();

                foreach (EnemyIndicatorObjectScript enemy in UnityEngine.Object.FindObjectsOfType(typeof(EnemyIndicatorObjectScript)) as EnemyIndicatorObjectScript[])
                {
                    // Apply and offset but its kinda trash if you change the fov
                    Vector3 anime_feet;
                    anime_feet.x = enemy.transform.position.x;
                    anime_feet.y = enemy.transform.position.y - 2.8f;
                    anime_feet.z = enemy.transform.position.z - 30f + Mathf.Sqrt(enemy.transform.position.x * enemy.transform.position.x + enemy.transform.position.y * enemy.transform.position.y);

                    LocalVariables.enemyPos.Add(anime_feet);
                }
            }
        }

        public void OnGUI()
        {
            if (!variables.Menu.menu_open && variables.CheatState.aimbot_bool && Input.GetKey(KeyCode.LeftAlt))
            {
                variables.ImportantVariables.myMouseLook.transform.LookAt(LocalVariables.enemyPos[1]);
                //variables.ImportantVariables.myMouseLook.yRotation++;
            }
        }
    }
}

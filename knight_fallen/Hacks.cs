using UnityEngine;



namespace knight_fallen
{
    class Hacks : MonoBehaviour
    {
        Player player = FindObjectOfType<Player>();
        Rose rose = FindObjectOfType<Rose>();
        NotificationHandler notif = FindObjectOfType<NotificationHandler>();
        LootDatabase lootDatabase = FindObjectOfType<LootDatabase>();

        Pl_Movement movement = FindObjectOfType<Pl_Movement>();
        Pl_Revive revive = FindObjectOfType<Pl_Revive>();

        public bool pressing = false;

        public void OnGUI()
        {
            GUI.enabled = true;
            GUI.Box(new Rect(10, 10, 250, 50), "");
            GUI.Label(new Rect(10, 10, 250, 30), "KNIGHT FALLEN v1.0 by LordTyler#6758");
            GUI.Label(new Rect(10, 30, 250, 30), "Good luck censoring this you fucks!");


            int c = 0;
                foreach (Player player in UnityEngine.Object.FindObjectsOfType(typeof(Player)) as Player[])
                {
                    c = c + 1;
                    if (pressing)
                    {
                        Vector3 pivotPos = player.transform.position;
                        Vector3 playerFootPos; playerFootPos.x = pivotPos.x; playerFootPos.y = pivotPos.y - 0f; playerFootPos.z = pivotPos.z;
                        Vector3 playerHeadPos; playerHeadPos.x = pivotPos.x; playerHeadPos.z = pivotPos.z; playerHeadPos.y = pivotPos.y + 4f;

                        Vector3 w2s_footpos = Camera.main.WorldToScreenPoint(playerFootPos);
                        Vector3 w2s_headpos = Camera.main.WorldToScreenPoint(playerHeadPos);

                        if (w2s_footpos.z > 0f)
                        {
                            DrawBoxESP(player, w2s_footpos, w2s_headpos, Color.red);
                            DrawLineESP(player, w2s_footpos, w2s_headpos, Color.red);
                        }

                    }
                }
            string msg = "Alive: " + c.ToString();
            GUI.Label(new Rect(10, 50, 200, 30), msg);
        }

        public void DrawBoxESP(Player player, Vector3 footpos, Vector3 headpos, Color color)
        {
            float height = headpos.y - footpos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;
            Render.DrawBox(footpos.x - (width / 2), (float)Screen.height - footpos.y - height, width, height, color, 1f);
        }
        public void DrawLineESP(Player player, Vector3 footpos, Vector3 headpos, Color color)
        {
            float height = headpos.y - footpos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;
            Render.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height)), new Vector2(footpos.x, (float)Screen.height - footpos.y), color, 1f);

            GUI.Label(new Rect(footpos.x, (float)Screen.height - footpos.y, 400, 30), player.data.playerName);
        }

        public void Update()
        {

            GUI.enabled = true;
            if (Input.GetKeyDown(KeyCode.V))
            {
                pressing = !pressing;
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                revive.Revive();
            }

        }

    }
}

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Fungus;
// namespace名称空间；
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    /// <summary>
    /// 目标 HUD 的图像
    /// </summary>
    public List<Sprite> TargetImages;

    public GameObject Player;
    public GameObject myCanvas;
    public GameObject Flowchart_Enter3D;
    /// <summary>
    /// 3D 场景中，找到目标的时间限制
    /// </summary>
    public float FindObjectTime = 30f;

    /// <summary>
    /// 上一个检查点的 UniqueId
    /// </summary>
    public string LastCheckpoint = "";

    /// <summary>
    /// 离开 2D 空间时的位置
    /// </summary>
    public Vector3 Last2DPosition;

    /// <summary>
    /// 所有已经收集的碎片，包括已经用掉的
    /// </summary>
    public List<string> CollectedShards;

    /// <summary>
    /// 当前可以使用的碎片数量
    /// </summary>
    public int ShardCount = 0;

    /// <summary>
    /// 消耗的碎片数量
    /// </summary>
    public int SpendCount = 3;

    /// <summary>
    /// 所有已经触发的对话
    /// </summary>
    public List<string> TriggeredFlowcharts;

    /// <summary>
    /// 穿越到3D世界的次数
    /// </summary>
    public int Switch3Dcount = 0;

    Text _textTimer;
    Text _textShard;
    float _timeLeft = 30f;
    bool _transitionBegan = false;


    public Vector3 currentPos;
    //
    public bool isOver_start;
    public bool isOver_switch;
    public bool isOver_111;
    public bool isOver_222;
    public bool isOver_333;            
    public bool isOver_444;
    public bool isOver_555;
    public bool isOver_666;
    public bool isOver_777;
    public bool isOver_888;
    public bool isOver_999;


    public bool shineOver;

    /// <summary>
    /// 拾取物体后的效果
    /// </summary>
    public bool canJump;
    public bool canBBGM;
    public bool canLight;
    public bool canBGM;
    public bool canPlant;
    public bool canSuperJump;
    public bool canShine;
    public bool canAttack;

    //门
    public bool doorIsOpen_1;
    public bool doorIsOpen_2;
    public bool doorIsOpen_3;
    public bool doorIsOpen_4;
    private void Start()
    {
        CollectedShards = new List<String>();
        TriggeredFlowcharts = new List<String>();
    }

    private void Awake()
    {
        // 不允许多个 manager 存在
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
     

        // manager 重置场景时保存（存储碎片/检查点信息）
        instance = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(myCanvas);
        DontDestroyOnLoad(Flowchart_Enter3D);
        

        SceneManager.sceneLoaded += OnSceneLoaded;
        // SceneManager.sceneUnloaded += OnSceneUnloaded;
        BlockSignals.OnBlockEnd += OnBlockEnd;


        _textShard = GameObject.Find("ShardText")?.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
        var scene_name = SceneManager.GetActiveScene().name;
        // 3D 场景下，30秒倒计时后激活传送对话
        if (!_transitionBegan && scene_name == "3D" )
        {
            _timeLeft -= Time.deltaTime;
            if (_timeLeft <= 0 || Interaction3D.canPick == false)
            {
                Cursor.lockState = CursorLockMode.None;
                GameObject.Find("Flowchart_Timeout").GetComponent<Flowchart>().ExecuteBlock("Start");
                _timeLeft = 0;
                _transitionBegan = true;
            }
            _textTimer.text = "Time: " + Math.Round(_timeLeft, 1);
        } else if (scene_name == "2D" && Player != null)
        {
            Last2DPosition = Player.transform.position;
        }

        /*
         Ray.pos  = new Vector3(Screen.width / 2.0f, Screen.height / 2.0f);
        //物品收集
        if (Ray.isComputer)
        {
            Destroy(GameObject.Find("computer"));
            canJump = true;
        }
        if (Ray.isErji)
        {
            Destroy(GameObject.Find("耳机"));
            canBBGM = true;
        }
        if (Ray.isNike)
        {
            Destroy(GameObject.Find("耐克"));
            PlayerController2D.m_JumpForce = 1000f;
        }
        */

        _textShard.text = " " + ShardCount;
    } 

    /// <summary>
    /// 收集 3D 物品后激活对应能力
    /// </summary>
    /// <param name="tag_name"></param>
    public bool ActivateAbility(Transform obj)
    {
        var tag_name = obj.tag;
        var picked = false;
        if (tag_name == "computer")
        {
            picked = true;
            canJump = true;
        }
        if (tag_name == "headset")
        {
            picked = true;
            canBBGM = true;
        }
      
        if(tag_name == "glasses")
        {
            picked = true;
            canLight = true;
        }
        if(tag_name == "buletooth")
        {
            picked = true;
            canBGM = true;
        }
        if (tag_name == "plant")
        {
            picked = true;
            canPlant = true;
        }
        if (tag_name == "Pan")
        {
            picked = true;
            canAttack = true;
        }
        /**
        if (picked)
        {
            obj.gameObject.SetActive(false);
        }
        **/
        return picked;
    }
   

    /// <summary>
    /// 收集一个碎片。
    /// </summary>
    /// <param name="shard">碎片类</param>
    public void CollectShard(Shard shard)
    {
        var id = shard.GetComponent<UniqueId>();

        // 不能重复收集碎片
        if (CollectedShards.Contains(id.uniqueId))
            return;

        CollectedShards.Add(id.uniqueId);
        ShardCount++;


        var total = CollectedShards.Count;
        /*
        // 每 7 个碎片触发 Fungus 的对话和场景转换
        if (total % 7 == 0)
        {
            FlowChartSwitch(total);
            对话时角色无法行动
            Player = GameObject.FindGameObjectWithTag("Player");
            Player.GetComponent<PlayerMovement>().canMove = false;
        }
        */
        FlowChartSwitch(CollectedShards.Count);
        
    }

    public void SetCanMoveToTrue()
    {
        Player.GetComponent<PlayerMovement>().canMove = true;
    }

    public void SetCanMoveToFalse()
    {
        Player.GetComponent<PlayerMovement>().canMove = false;
    }

    public void setCanvas()
    {
        myCanvas.SetActive(true);
    }
    

    /// <summary>
    /// 重置当前场景。玩家的位置会设置在上一个存档点（如果有）。
    /// </summary>
    public void Reload()
    {
        // 不使用上次位置而返回检查点
        Last2DPosition = Vector3.zero;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    /// <summary>
    /// 对话内容转换方法，在7 14 21 28时候调用
    /// </summary>
    /// <param name="a">碎片数量</param>
    private void FlowChartSwitch(int a)
    {
        var flowchartGameObject = GameObject.Find("Flowchart_Enter3D");
        var comp = flowchartGameObject.GetComponent<Flowchart>();
        comp.SetIntegerVariable("TotalShardCount", a);
        comp.ExecuteBlock("Start");

    }
  


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "2D")
        {
            // 2D 场景
            Player = GameObject.FindGameObjectWithTag("Player");
            _textShard = GameObject.Find("ShardText").GetComponent<Text>();

            if (canBBGM)
            {
                GameObject.Find("Audio Source").GetComponent<AudioSource>().volume = 1;
            }
            if (canLight)
            {
                GameObject.Find("Global Light 2D").SetActive(false);
            }
            if (canBGM)
            {

            }
            if (canPlant)
            {
                GameObject Plants = GameObject.Find("Plants");
                GameObject Plant = Plants.transform.Find("Plant").gameObject;
                Plant.SetActive(true);
            }

            if (canShine)
            {
                GameObject Shine_float = GameObject.Find("Shine_float");
                GameObject Shine = Shine_float.transform.Find("float").gameObject;
                Shine.SetActive(true);
                GameObject.Find("耀").SetActive(false);
            }

            // 还原碎片和对话进度
            foreach (Shard shard in FindObjectsOfType<Shard>())
            {
                if (CollectedShards.Contains(shard.GetComponent<UniqueId>().uniqueId))
                    shard.SetCollected(true);
            }
            foreach (var flowchart in FindObjectsOfType<Flowchart>())
            {
                var uniqueId = flowchart.GetComponent<UniqueId>();
                if (uniqueId != null && TriggeredFlowcharts.Contains(uniqueId.uniqueId))
                    Destroy(flowchart.gameObject);
            }

            // 还原玩家位置
            if (Last2DPosition != null && Last2DPosition != Vector3.zero)
            {
                Player.transform.position = Last2DPosition;
                Last2DPosition = Vector3.zero;
            } else if (LastCheckpoint != null)
            {
                foreach (Checkpoint cp in FindObjectsOfType<Checkpoint>())
                {
                    if (cp.GetComponent<UniqueId>().uniqueId == LastCheckpoint)
                    {
                        Player.transform.position = cp.transform.position;
                        break;
                    }

                }
            }
            if (doorIsOpen_1)
            {
                Debug.Log("111");
                Destroy(GameObject.Find("key_1"));
            }
            if (doorIsOpen_2)
            {
                Destroy(GameObject.Find("key_2"));
            }
            if (doorIsOpen_3)
            {
                Destroy(GameObject.Find("key_3"));
                Destroy(GameObject.Find("Door_2"));
            }
            if (doorIsOpen_4)
            {
                Destroy(GameObject.Find("Door_4"));
            }

            if (isOver_111)
            {
                GameObject.Find("Flowchart_111").SetActive(false);
            }
            if (isOver_222)
            {
                GameObject.Find("Flowchart_222").SetActive(false);
            }
            if (isOver_333)
            {
                GameObject.Find("Flowchart_333").SetActive(false);
            }
            if (isOver_444)
            {
                GameObject.Find("Flowchart_444").SetActive(false);
            }
            if (isOver_555)
            {
                GameObject.Find("Flowchart_555").SetActive(false);
            }
            if (isOver_777)
            {
                GameObject.Find("Flowchart_777").SetActive(false);
            }
            if (isOver_888)
            {
                GameObject.Find("Flowchart_888").SetActive(false);
            }
            if (isOver_999)
            {
                GameObject.Find("Flowchart_999").SetActive(false);
            }
            if (isOver_666)
            {
                GameObject.Find("Flowchart_666").SetActive(false);
            }

        } else if (scene.name == "3D")
        {
            // 3D 场景
            
            if (canJump)
            {
                GameObject.Find("computer").transform.position = new Vector3(0, 0, 0);
            }
            if (canBBGM)
            {
                GameObject.Find("耳机").transform.position = new Vector3(0, 0, 0);
            }
            if (canLight)
            {
                GameObject.Find("眼镜").transform.position = new Vector3(0, 0, 0);
            }
            if (canBGM)
            {
                GameObject.Find("音响").transform.position = new Vector3(0, 0, 0);
            }
           
            if (canPlant)
            {
                GameObject.Find("Plant").transform.position = new Vector3(0, 0, 0);
            }
            if (canAttack)
            {
                GameObject.Find("平底锅").transform.position = new Vector3(0,0,0);
            }



            Switch3Dcount++;
            _transitionBegan = false;
            _timeLeft = FindObjectTime;
            _textTimer = GameObject.Find("Text_TimeLeft").GetComponent<Text>();
            ShardCount -= SpendCount;
            var image = GameObject.FindGameObjectWithTag("TargetCanvas").GetComponent<Image>();
            image.sprite = TargetImages[Switch3Dcount - 1];
            //从2D来到3D时开启voluem；
            PlayerController2D.isDead = true;
        }
        //从3D返回2D时关闭voluem；
        if(scene.name == "2D" && PlayerController2D.isDead){
            PlayerController2D.isDead = false;
        }
    }

    private void OnSceneUnloaded(Scene scene)
    {

    }

    void OnBlockEnd(Block block)
    {
        Debug.Log("Block ended: " + block.BlockName);
        /*
        if (block.BlockName == "ReturnTo2D")
        {
            SceneManager.LoadScene("2D");
        }
        */
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class LeapGesture3 : MonoBehaviour
{

#if UNITY_STANDALONE_WIN
	[DllImport("mono", SetLastError=true)]
	static extern void mono_thread_exit();
#endif

    // DELEGATE
    public delegate void onGestureRecognised(EasyLeapGesture2 gesture);
    public static event onGestureRecognised GestureRecognised;

 
    private Leap.Controller leapController;
    private Leap.Frame mFrame;
    private Dictionary<int, EasyLeapGesture2> gestureList = new Dictionary<int, EasyLeapGesture2>();

    public static bool circleGesture = false;
    public static bool swipeGesture = false;
    public static bool keytapGesture = false;
    public static bool screentapGesture = false;
    public static bool numbersGesture = false;
    public static bool closeFist = false;
    public static bool openFist = false;
    public bool SitGesture = false;
    public bool JumpGesture = false;
    public bool ZoomoutGesture = false;
    public bool ZoomInGesture = false;
    public static bool clapGesture = false;
    public static bool twoFingerKeytap = false;
    public static bool threeFingerKeytap = false;
    public static bool twoFingerScreentap = false;
    public static bool threeFingerScreentap = false;
    public static bool steeringWheel = false;
    public static bool doublePushGesture = false;
    public static bool doublePullGesture = false;
    public static bool doubleLeftPushRightPullGesture = false;
    public static bool doubleLeftPullRightPushGesture = false;
    public bool GoStop = false;
    public bool LeftDirection = false;
    public bool RightDirection = false;
    public bool Shot = false;
    public bool LeftLotation = false;
    public bool RightLotation = false;
    public bool Roll = false;
    public bool RacingLeftRightForward = false;
    public bool RacingStopGesture = false;
	public bool LearningPlay = true;
    public bool LearningPause = false;
    public bool LearningFastPlay = false;
    public bool LearningRewind = false;
    public bool GoShot = false;
    public bool LeftDirectionShot = false;
    public bool RightDirectionShot = false;
    public bool LeftGo = false;
    public bool RightGo = false;
    private float pushRestTime = 0f;
    private float pullRestTime = 0f;
    private float doubleInSwipeRestTime = 0f;
    private float doubleOutSwipeRestTime = 0f;
    private float clapRestTime = 0f;

	//Clay와 관련된 변수
    public GameObject Pin;
	public GameObject Parete;
    public GameObject MUD2;
	public GameObject[] CloneMud=new GameObject[30];
	public GameObject PrefabClay;
	public Transform SpotPoint;
	public Material[] CloneMaterial = new Material[30];
	public Material resetMaterial;
	public bool PareteEnable=true;
	public bool PareteTurm=true;
	public bool PrefabCreat=true;
    public bool PinRotate = false;
	public int Reculsive=0;
    
    // Use this for initialization
    void Start()
    {
        leapController = new Leap.Controller();
        leapController.EnableGesture(Leap.Gesture.GestureType.TYPECIRCLE, true);
        leapController.EnableGesture(Leap.Gesture.GestureType.TYPESWIPE, true);
        leapController.EnableGesture(Leap.Gesture.GestureType.TYPEKEYTAP, true);
        leapController.EnableGesture(Leap.Gesture.GestureType.TYPESCREENTAP, true);
//		for (int i=0; i<30; i++) {
//			CloneMaterial[i]=Instantiate(resetMaterial)as Material;
//		}
    }

    // Update is called once per frame
    void Update()
    {
        mFrame = leapController.Frame();
        int LeftfingerCount = 0;
        int fingerCount = 0;
        int RightfingerCount = 0;
        if (GoStop || closeFist || openFist ||
                keytapGesture || twoFingerKeytap || threeFingerKeytap ||
                screentapGesture || twoFingerScreentap || threeFingerScreentap || steeringWheel || doublePushGesture || doublePullGesture || doubleLeftPushRightPullGesture || doubleLeftPullRightPushGesture || GoStop || LeftDirection || RightDirection || Shot || LeftLotation || RightLotation || Roll || LearningPlay || LearningPause || LeftDirectionShot || RightDirectionShot || LeftGo || RightGo || GoShot)
        {
            fingerCount = GetFingerCount();
            LeftfingerCount = GetLeftFingerCount();
            RightfingerCount = GetRightFingerCount();
        }
        
        if (PinRotate == true)
        {
            Pin.transform.Rotate(Vector3.up * -40 * Time.deltaTime);

        }

        /*foreach(Leap.Gesture gesture in mFrame.Gestures ()) {
            switch(gesture.Type) {
                case Leap.Gesture.GestureType.TYPECIRCLE:
                    if(circleGesture) BuiltInGestureRecognised(gesture,EasyLeapGesture2Type.TYPECIRCLE);
                    break;
                case Leap.Gesture.GestureType.TYPESWIPE:
                    if(swipeGesture) BuiltInGestureRecognised(gesture,EasyLeapGesture2Type.TYPESWIPE);
                    break;
                case Leap.Gesture.GestureType.TYPEKEYTAP:
                    if(keytapGesture && fingerCount == 1) BuiltInGestureRecognised(gesture,EasyLeapGesture2Type.TYPEKEYTAP);
                    if(twoFingerKeytap && fingerCount == 2) BuiltInImprovedGestureRecognised(gesture,EasyLeapGesture2Type.TWO_FINGERS_KEYTAP);
                    if(threeFingerKeytap && fingerCount == 3) BuiltInImprovedGestureRecognised(gesture,EasyLeapGesture2Type.THREE_FINGERS_KEYTAP);
                    break;
                case Leap.Gesture.GestureType.TYPESCREENTAP:
                    if(screentapGesture && fingerCount == 1) BuiltInGestureRecognised(gesture,EasyLeapGesture2Type.TYPESCREENTAP);
                    if(twoFingerScreentap && fingerCount == 2) BuiltInImprovedGestureRecognised(gesture,EasyLeapGesture2Type.TWO_FINGERS_SCREENTAP);
                    if(threeFingerScreentap && fingerCount == 3) BuiltInImprovedGestureRecognised(gesture,EasyLeapGesture2Type.THREE_FINGERS_SCREENTAP);
                    break;
            }
			
        }*/
        if (mFrame.Gestures().Count == 0) ClearDraggingGestures();

        if (GoStop)            
        {
            if (mFrame.Hands.Count == 1) //손이 1개 일때
            {
                bool leftHand = mFrame.Hands.Frontmost.IsLeft; //왼손인지 판단

                switch (LeftfingerCount) //왼쪽 손가락 갯수 판단
                {
                    case 0: //멈추는거
                        // NO FINGERS
                        if (GoStop && leftHand)
                        {
                            GoStopRecognised(EasyLeapGesture2Type.DEFAULT);
                            if (PinRotate == true)
                            {
                                PinRotate = false;
                            }
                            Debug.Log("Stop");
                        }
                        break;
                    case 5: //멈추는거
                        if (GoStop && leftHand)
                        {
                            GoStopRecognised(EasyLeapGesture2Type.FIVE);
                            Debug.Log("Forward");
                        }
                        break;
                }
            }

            else if (mFrame.Hands.Count == 2) //손이 2개 일 때
            {
                switch (LeftfingerCount) 
                {
                    case 0: 
                        // NO FINGERS
                        if (GoStop)
                        {
                            GoStopRecognised(EasyLeapGesture2Type.DEFAULT);
                            Debug.Log("Stop2");
                        }
                        break;
                    case 5:
                        if (GoStop)
                        {
                            GoStopRecognised(EasyLeapGesture2Type.FIVE);
                            Debug.Log("Forward2");
                        }
                        break;
                }
            }
        }

        if (LeftDirection) //왼쪽 방향
        {
            if (mFrame.Hands.Count == 1)
            {
                bool leftHand = mFrame.Hands.Frontmost.IsLeft; 
                if (LeftDirection && leftHand)
                {
                    if (mFrame.Hands.Leftmost.Direction.Yaw < -0.5) LeftDirectionGestureRecognised(EasyLeapGesture2State.STATESTART); //x,z축의 각도
                    else LeftDirectionGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                }
                /*else if (RightDirection && leftHand)
                {
                    if (mFrame.Hands.Leftmost.Direction.Yaw > 0.5) PushGestureRecognised(EasyLeapGesture2State.STATESTART);
                    else PushGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                }*/
            }
            else if (mFrame.Hands.Count == 2)
            {
                bool leftHand2 = mFrame.Hands.Leftmost.IsLeft;
                if (LeftDirection && leftHand2)
                {
                    if (mFrame.Hands.Leftmost.Direction.Yaw < -0.5) LeftDirectionGestureRecognised(EasyLeapGesture2State.STATESTART);
                    else LeftDirectionGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                }
                /*else if (RightDirection && leftHand2)
                {
                    if (mFrame.Hands.Leftmost.Direction.Yaw > 0.5) PushGestureRecognised(EasyLeapGesture2State.STATESTART);
                    else PushGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                }*/
            }
        }

        if (RightDirection) //오른쪽 방향
        {
            if (mFrame.Hands.Count == 1)
            {
                bool leftHand = mFrame.Hands.Frontmost.IsLeft;
                if (RightDirection && leftHand)
                {
                    if (mFrame.Hands.Leftmost.Direction.Yaw > 0.5) RightDirectionGestureRecognised(EasyLeapGesture2State.STATESTART);
                    else RightDirectionGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                }
            }
            else if (mFrame.Hands.Count == 2)
            {
                bool leftHand2 = mFrame.Hands.Leftmost.IsLeft;
                if (RightDirection && leftHand2)
                {
                    if (mFrame.Hands.Leftmost.Direction.Yaw > 0.5) RightDirectionGestureRecognised(EasyLeapGesture2State.STATESTART);
                    else RightDirectionGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                }
            }
        }

        if (Shot) //쏘는 거
        {
            if (mFrame.Hands.Count == 1)
            {
                bool rightHand = mFrame.Hands.Frontmost.IsRight;

                switch (RightfingerCount)
                {
                    case 2:
                        if (rightHand && mFrame.Fingers.FingerType(Leap.Finger.FingerType.TYPE_THUMB).Leftmost.Direction.Yaw > 0.05) //엄지손가락의 범위
                        {
                            ShotGestureRecognised(EasyLeapGesture2Type.DEFAULT);
                            Debug.Log("Shot");
                        }
                        break;
                }
            }
            else if (mFrame.Hands.Count == 2)
            {

                switch (RightfingerCount)
                {
                    case 2:
                        if (mFrame.Hands.Rightmost.Fingers.FingerType(Leap.Finger.FingerType.TYPE_THUMB).Leftmost.Direction.Yaw > 0.05)
                        {
                            ShotGestureRecognised(EasyLeapGesture2Type.DEFAULT);
                            Debug.Log("Shot");
                        }
                        break;
                }
            }
        }

        if (SitGesture || JumpGesture) //앉기, 점프 제스처
        {
            if (mFrame.Hands.Count == 1)
            {
                if (SitGesture)
                {
                    if (mFrame.Hands[0].PalmVelocity.y < -EasyLeapGesture2.MinPushPullVelocity) PushGestureRecognised(EasyLeapGesture2State.STATESTART);
                    else PushGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                }
                if (JumpGesture)
                {
                    if (mFrame.Hands[0].PalmVelocity.y > EasyLeapGesture2.MinPushPullVelocity) PullGestureRecognised(EasyLeapGesture2State.STATESTART);
                    else PullGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                }
            }
            else
            {
                PushGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                PullGestureRecognised(EasyLeapGesture2State.STATEINVALID);
            }
        }

        if (LearningPlay) //콘텐츠 강의 재생
        {
            if (mFrame.Hands.Count == 2)
            {
                bool leftHandSwipeIn = (!PalmIsHorizontal(mFrame.Hands.Leftmost)) && mFrame.Hands.Leftmost.PalmVelocity.x > EasyLeapGesture2.MinClapVelocity;
                bool rightHandSwipeIn = (!PalmIsHorizontal(mFrame.Hands.Rightmost)) && mFrame.Hands.Rightmost.PalmVelocity.x < -EasyLeapGesture2.MinClapVelocity;
                if (leftHandSwipeIn && rightHandSwipeIn)
                {
                    if (mFrame.Hands[0].StabilizedPalmPosition.DistanceTo(mFrame.Hands[1].StabilizedPalmPosition) < EasyLeapGesture2.MaxPalmClapDistance)
                    {
                        LearningPlayGestureRecognised(EasyLeapGesture2State.STATESTART);
						if(PrefabCreat==true)
						{
							Debug.Log(Reculsive);
							PrefabCreat=false;
							CloneMud[Reculsive] = Instantiate(PrefabClay, SpotPoint.position, SpotPoint.rotation)as GameObject;
							CloneMud[Reculsive].GetComponent<Renderer>().material=CloneMaterial[Reculsive];
							Reculsive+=1;
							StartCoroutine("ClayPrefab");
						}
                    }
                }
                else LearningPlayGestureRecognised(EasyLeapGesture2State.STATEINVALID);
            }
        }

        if (LearningPause) //콘텐츠 강의 정지
        {
            if (mFrame.Hands.Count == 1) //손이 1개 일때
            {
				bool RightHand = mFrame.Hands.Frontmost.IsLeft; //왼ㅗㄴ인지 판단

                if(RightfingerCount < 3)
                {
                        if (RightHand)
                        {
						if(PareteTurm==true)
						{
							if(PareteEnable==true)
							{
								Parete.SetActive(false);
								PareteEnable=false;
							}
							else if(PareteEnable==false)
							{
								Parete.SetActive(true);
								PareteEnable=true;
							}
								StartCoroutine("PareteCorutine");
						}	
							GoStopRecognised(EasyLeapGesture2Type.DEFAULT);
                            Debug.Log("Pause");
						if(PinRotate==true)
						{
							PinRotate = false;
						}

                        }
                }
            }
        }

        if (LearningFastPlay || LearningRewind) //콘텐츠 강의 빠른 재생, 콘텐츠 강의 되감기
        {
            if (mFrame.Hands.Count == 1)
            {
                bool leftHandSwipeOut = (PalmIsHorizontal(mFrame.Hands.Leftmost)) && mFrame.Hands.Leftmost.PalmVelocity.x < -EasyLeapGesture2.MinSwipeVelocity;
                bool rightHandSwipeOut = (PalmIsHorizontal(mFrame.Hands.Rightmost)) && mFrame.Hands.Rightmost.PalmVelocity.x > EasyLeapGesture2.MinSwipeVelocity;
                if (LearningFastPlay && rightHandSwipeOut) //빠른 재생
                {
                    ZoomInGestureRecognised(EasyLeapGesture2State.STATESTART);
                    Debug.Log("LearningFastPlay");
                
                }
                else if (LearningRewind && leftHandSwipeOut) //되감기
                {
                    ZoomInGestureRecognised(EasyLeapGesture2State.STATESTART);
                    Debug.Log("LearningRewind");
					GameObject.FindWithTag ("CLAY").GetComponent<MeshDeformer> ().springForce = 5.0f;
					StartCoroutine ("SpringRewind");
                }
                else ZoomInGestureRecognised(EasyLeapGesture2State.STATEINVALID);
            }
        }

        if (LeftDirectionShot) //왼쪽 방향으로 쏘다
        {
            if (mFrame.Hands.Count == 2)
            {
                bool leftHand2 = mFrame.Hands.Leftmost.IsLeft;

                if (LeftDirectionShot && leftHand2)
                {
                    if (mFrame.Hands.Leftmost.Direction.Yaw < -0.5)
                    {
                        switch (RightfingerCount)
                        {
                            case 2:
                                if (mFrame.Hands.Rightmost.Fingers.FingerType(Leap.Finger.FingerType.TYPE_THUMB).Leftmost.Direction.Yaw > 0.05)
                                {
                                    ShotGestureRecognised(EasyLeapGesture2Type.DEFAULT);
                                    Debug.Log("Shot");
                                }
                                break;
                        }
                    }
                    else RightDirectionGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                }
            }    
        }

        if (RightDirectionShot) //오른쪽 방향으로 쏘다
        {
            if (mFrame.Hands.Count == 2)
            {
                bool RightHand2 = mFrame.Hands.Leftmost.IsLeft;

                if (RightDirectionShot && RightHand2)
                {
                    if (mFrame.Hands.Leftmost.Direction.Yaw > 0.5)
                    {
                        switch (RightfingerCount)
                        {
                            case 2:
                                if (mFrame.Hands.Rightmost.Fingers.FingerType(Leap.Finger.FingerType.TYPE_THUMB).Leftmost.Direction.Yaw > 0.05)
                                {
                                    ShotGestureRecognised(EasyLeapGesture2Type.DEFAULT);
                                    Debug.Log("Shot");
                                }
                                break;
                        }
                    }
                    else LeftDirectionGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                }
            }
        }

        if (ZoomoutGesture || ZoomInGesture) //확대, 축소
        {
            if (mFrame.Hands.Count == 2)
            {
                bool leftHandSwipeIn = (PalmIsHorizontal(mFrame.Hands.Leftmost)) && mFrame.Hands.Leftmost.PalmVelocity.x > EasyLeapGesture2.MinSwipeVelocity;
                bool rightHandSwipeIn = (PalmIsHorizontal(mFrame.Hands.Rightmost)) && mFrame.Hands.Rightmost.PalmVelocity.x < -EasyLeapGesture2.MinSwipeVelocity;
                if (ZoomoutGesture && (leftHandSwipeIn && rightHandSwipeIn))
                {
                    if (mFrame.Hands[0].StabilizedPalmPosition.DistanceTo(mFrame.Hands[1].StabilizedPalmPosition) < EasyLeapGesture2.MaxPalmDistance) ZoomoutGestureRecognised(EasyLeapGesture2State.STATESTART);
                }
                else ZoomoutGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                bool leftHandSwipeOut = (PalmIsHorizontal(mFrame.Hands.Leftmost)) && mFrame.Hands.Leftmost.PalmVelocity.x < -EasyLeapGesture2.MinSwipeVelocity;
                bool rightHandSwipeOut = (PalmIsHorizontal(mFrame.Hands.Rightmost)) && mFrame.Hands.Rightmost.PalmVelocity.x > EasyLeapGesture2.MinSwipeVelocity;
                if (ZoomInGesture && leftHandSwipeOut && rightHandSwipeOut)
                {
                    if (mFrame.Hands[0].StabilizedPalmPosition.DistanceTo(mFrame.Hands[1].StabilizedPalmPosition) > EasyLeapGesture2.MaxPalmDistance) ZoomInGestureRecognised(EasyLeapGesture2State.STATESTART);
                }
                else ZoomInGestureRecognised(EasyLeapGesture2State.STATEINVALID);
            }
        }
        if (LeftLotation || RightLotation) //왼쪽 오른쪽 회전
        {
            if (mFrame.Hands.Count == 1)
            {
                bool isleftHand = mFrame.Hands.Frontmost.IsLeft;
                bool isrightHand = mFrame.Hands.Frontmost.IsRight;
                bool leftHandSwipeIn = (!PalmIsHorizontal(mFrame.Hands.Leftmost)) && mFrame.Hands.Leftmost.PalmVelocity.x > EasyLeapGesture2.MinClapVelocity;
                bool rightHandSwipeIn = (!PalmIsHorizontal(mFrame.Hands.Rightmost)) && mFrame.Hands.Rightmost.PalmVelocity.x < -EasyLeapGesture2.MinClapVelocity;
                if (leftHandSwipeIn && LeftLotation && isleftHand)
                {
					Debug.Log("Left");
                    if (PinRotate == false)
                    {
                        PinRotate = true;
                    }
                    LeftRightRecognised(EasyLeapGesture2State.STATESTART);

                }
                else if (RightLotation && rightHandSwipeIn && isrightHand)
                {
                    LeftRightRecognised(EasyLeapGesture2State.STATESTART);
                }
                else LeftRightRecognised(EasyLeapGesture2State.STATEINVALID);
            }
        }

        if (Roll) //구르기
        {
            if (mFrame.Hands.Count == 1)
            {
                bool leftHand = mFrame.Hands.Frontmost.IsLeft;
                if (Roll && leftHand)
                {
                    if (mFrame.Hands.Leftmost.PalmPosition.z < -100f) RollGestureRecognised(EasyLeapGesture2State.STATESTART); //x축의 위치
                    else RollGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                }
                /*else if (RightDirection && leftHand)
                {
                    if (mFrame.Hands.Leftmost.Direction.Yaw > 0.5) PushGestureRecognised(EasyLeapGesture2State.STATESTART);
                    else PushGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                }*/
            }
            else if (mFrame.Hands.Count == 2)
            {
                bool leftHand2 = mFrame.Hands.Leftmost.IsLeft;
                if (Roll && leftHand2)
                {
                    if (mFrame.Hands.Leftmost.PalmPosition.z < -100f) RollGestureRecognised(EasyLeapGesture2State.STATESTART);
                    else RollGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                }
                /*else if (RightDirection && leftHand2)
                {
                    if (mFrame.Hands.Leftmost.Direction.Yaw > 0.5) PushGestureRecognised(EasyLeapGesture2State.STATESTART);
                    else PushGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                }*/
            }
        }

        if (RacingLeftRightForward) //레이싱게임 왼쪽/오른쪽 방향
        {
            if (mFrame.Hands.Count == 2)
            {
                bool leftHand = (PalmIsHorizontal(mFrame.Hands.Leftmost));
                bool RightHand = (PalmIsHorizontal(mFrame.Hands.Rightmost));
                if (RacingLeftRightForward && leftHand && RightHand)
                {
                    if (mFrame.Hands.Leftmost.PalmPosition.y - mFrame.Hands.Rightmost.PalmPosition.y < -100)  //손바닥 y축의 위치
                    {
                        RightDirectionGestureRecognised(EasyLeapGesture2State.STATESTART);
                    }

                    else if (mFrame.Hands.Leftmost.PalmPosition.y - mFrame.Hands.Rightmost.PalmPosition.y > 100)
                    {
                        LeftDirectionGestureRecognised(EasyLeapGesture2State.STATESTART);
                    }
                    else 
                    {
                        GoForwardRecognised(EasyLeapGesture2State.STATESTART);
                    }
                }
            }
        }

        if (RacingStopGesture) //레이싱게임 왼쪽/오른쪽 방향
        {
            if (mFrame.Hands.Count == 2)
            {
                bool leftHand = (!PalmIsHorizontal(mFrame.Hands.Leftmost));
                bool RightHand = (!PalmIsHorizontal(mFrame.Hands.Rightmost));
                if (RacingStopGesture && leftHand && RightHand)
                {
                    if (RacingStopGesture)
                    {
                        StopRecognised(EasyLeapGesture2State.STATESTART);
                    }
                }
            }
        }

        if (clapGesture)
        {
            if (mFrame.Hands.Count == 2)
            {
                bool leftHandSwipeIn = (!PalmIsHorizontal(mFrame.Hands.Leftmost)) && mFrame.Hands.Leftmost.PalmVelocity.x > EasyLeapGesture2.MinClapVelocity;
                bool rightHandSwipeIn = (!PalmIsHorizontal(mFrame.Hands.Rightmost)) && mFrame.Hands.Rightmost.PalmVelocity.x < -EasyLeapGesture2.MinClapVelocity;
                if (leftHandSwipeIn && rightHandSwipeIn)
                {
                    if (mFrame.Hands[0].StabilizedPalmPosition.DistanceTo(mFrame.Hands[1].StabilizedPalmPosition) < EasyLeapGesture2.MaxPalmClapDistance) ClapRecognised(EasyLeapGesture2State.STATESTART);
                }
                else ClapRecognised(EasyLeapGesture2State.STATEINVALID);
            }
        }

        if (LeftGo) //왼쪽 방향으로 가다
        {
            if (mFrame.Hands.Count == 1)
            {
                bool leftHand2 = mFrame.Hands.Frontmost.IsLeft;
                if (LeftGo && leftHand2)
                {
                    if (mFrame.Hands.Leftmost.Direction.Yaw < -0.5) 
                    {
                        switch(LeftfingerCount)
                        {
                            case 5:
                                if(LeftGo&& leftHand2)
                                {
                                    GoStopRecognised(EasyLeapGesture2Type.FIVE);
                                    Debug.Log("Forward");
                                }
                                 break;
                        }
                        LeftDirectionGestureRecognised(EasyLeapGesture2State.STATESTART);
                    }
                    else LeftDirectionGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                }
            }
        }

        if (RightGo) //오른쪽 방향으로 가다
        {
            if (mFrame.Hands.Count == 1)
            {
                bool leftHand2 = mFrame.Hands.Frontmost.IsLeft;
                if (RightGo && leftHand2)
                {
                    if (mFrame.Hands.Leftmost.Direction.Yaw > 0.5)
                    {
                        switch (LeftfingerCount)
                        {
                            case 5:
                                if (RightGo && leftHand2)
                                {
                                    GoStopRecognised(EasyLeapGesture2Type.FIVE);
                                    Debug.Log("Forward2");
                                }
                                break;
                        }
                        LeftDirectionGestureRecognised(EasyLeapGesture2State.STATESTART);
                    }
                    else LeftDirectionGestureRecognised(EasyLeapGesture2State.STATEINVALID);
                }
            }
        }

        if (GoShot)
        {
                if (mFrame.Hands.Count == 2) //손이 2개 일 때
            {
                switch (LeftfingerCount) 
                {
                    case 5:
                        if (GoShot)
                        {
                            switch (RightfingerCount)
                            {
                                case 2:
                                    if (mFrame.Hands.Rightmost.Fingers.FingerType(Leap.Finger.FingerType.TYPE_THUMB).Leftmost.Direction.Yaw > 0.05)
                                    {
                                        ShotGestureRecognised(EasyLeapGesture2Type.DEFAULT);
                                        Debug.Log("GoShot");
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
        }

 

        /*
        if(steeringWheel) {
            float palmsAngle = (mFrame.Hands.Leftmost.PalmNormal.AngleTo(mFrame.Hands.Rightmost.PalmNormal)*Mathf.Rad2Deg);
            if(mFrame.Hands.Count >= 1 && fingerCount < 2 && (palmsAngle > 110 || palmsAngle < 70)) {
                Leap.Vector leftMost = mFrame.Hands.Leftmost.StabilizedPalmPosition;
                Leap.Vector rightMost = mFrame.Hands.Rightmost.StabilizedPalmPosition;
                Leap.Vector steerVector = (leftMost - rightMost).Normalized;
                //steerVector.z = 0;
                float angle = steerVector.AngleTo(Leap.Vector.Left)*Mathf.Rad2Deg * (leftMost.y > rightMost.y ? 1 : -1);
                SteeringWheelRecognised(angle, Mathf.Abs (leftMost.z) - Mathf.Abs (rightMost.z));
            }
        }*/

        // Send gestures detected to all registered gesture listeners
        SendGesturesToListeners();
    }

    // BUGGY: clear any gestures that have not been removed properly from the list -- to improve
    private void ClearDraggingGestures()
    {
        if (gestureList.Count == 0) return;
        var keys = new List<int>(gestureList.Keys);
        foreach (int cKey in keys)
        {
            if (gestureList[cKey].Type == EasyLeapGesture2Type.TYPECIRCLE || gestureList[cKey].Type == EasyLeapGesture2Type.TYPESWIPE)
            {
                EasyLeapGesture2 g = gestureList[cKey];
                g.State = EasyLeapGesture2State.STATESTOP;
                gestureList[cKey] = g;
            }
        }
    }
    // Store the recognised gesture on the gesture List
    private void RecordNewGesture(int id, EasyLeapGesture2State startState, EasyLeapGesture2State updateState, EasyLeapGesture2Type type, long duration, Leap.Vector position)
    {
        if (gestureList.ContainsKey(id))
        {
            EasyLeapGesture2 g = gestureList[id];
            g.State = updateState;
            g.Duration = duration < 0 ? (long)(1000000 * Time.deltaTime) + g.Duration : duration;
            gestureList[id] = g;
        }
        else
        {
            EasyLeapGesture2 gest = new EasyLeapGesture2();
            gest.Duration = 0;
            gest.Id = id;
            gest.State = startState;
            gest.Type = type;
            gest.Frame = mFrame;
            gest.Position = position;
            gestureList.Add(id, gest);
        }
    }
    /*
	// Individual gesture start-stop handler
	private void SteeringWheelRecognised(float angle, float zDepth) {
		RecordNewGesture(-(int)EasyLeapGesture2Type.STEERING_WHEEL,EasyLeapGesture2State.STATESTOP,EasyLeapGesture2State.STATESTOP,EasyLeapGesture2Type.STEERING_WHEEL,0,new Leap.Vector(angle,angle,zDepth));
        Debug.Log("SteeringWheelRecognised");
    }
    */
    private void ClapRecognised(EasyLeapGesture2State state)
    {
        if (state == EasyLeapGesture2State.STATEINVALID || Time.time < clapRestTime + EasyLeapGesture2.ClapRecoveryTime)
        {
            gestureList.Remove(-(int)EasyLeapGesture2Type.CLAP);
            return;
        }
        clapRestTime = Time.time;
        RecordNewGesture(-(int)EasyLeapGesture2Type.CLAP, EasyLeapGesture2State.STATESTART, EasyLeapGesture2State.STATEUPDATE, EasyLeapGesture2Type.CLAP, -1, new Leap.Vector(mFrame.Hands[0].StabilizedPalmPosition.x + mFrame.Hands[1].StabilizedPalmPosition.x, mFrame.Hands[0].StabilizedPalmPosition.y, mFrame.Hands[0].StabilizedPalmPosition.z));
        Debug.Log("ClapRecognised");
        //mAnimator = chracter.GetComponent<Animation>();
        //mAnimator.Play("rolling2");
    }
    private void ZoomoutGestureRecognised(EasyLeapGesture2State state)
    {
        if (state == EasyLeapGesture2State.STATEINVALID || Time.time < doubleInSwipeRestTime + EasyLeapGesture2.DoubleInwardsRecoveryTime)
        {
            gestureList.Remove(-(int)EasyLeapGesture2Type.DOUBLE_SWIPE_IN);
            return;
        }
        doubleInSwipeRestTime = Time.time;
        RecordNewGesture(-(int)EasyLeapGesture2Type.DOUBLE_SWIPE_IN, EasyLeapGesture2State.STATESTART, EasyLeapGesture2State.STATEUPDATE, EasyLeapGesture2Type.DOUBLE_SWIPE_IN, -1, new Leap.Vector(mFrame.Hands[0].StabilizedPalmPosition.x + mFrame.Hands[1].StabilizedPalmPosition.x, mFrame.Hands[0].StabilizedPalmPosition.y, mFrame.Hands[0].StabilizedPalmPosition.z));
        Debug.Log("ZoomoutGestureRecognised");
        //mAnimator = chracter.GetComponent<Animation>();
        //mAnimator.Play("dodging");
    }
    private void LearningPlayGestureRecognised(EasyLeapGesture2State state) //강의 재생 인식
    {
        if (state == EasyLeapGesture2State.STATEINVALID || Time.time < clapRestTime + EasyLeapGesture2.ClapRecoveryTime)
        {
            gestureList.Remove(-(int)EasyLeapGesture2Type.LEARNINGPLAY);
            return;
        }
        clapRestTime = Time.time;
        RecordNewGesture(-(int)EasyLeapGesture2Type.LEARNINGPLAY, EasyLeapGesture2State.STATESTART, EasyLeapGesture2State.STATEUPDATE, EasyLeapGesture2Type.LEARNINGPLAY, -1, new Leap.Vector(mFrame.Hands[0].StabilizedPalmPosition.x + mFrame.Hands[1].StabilizedPalmPosition.x, mFrame.Hands[0].StabilizedPalmPosition.y, mFrame.Hands[0].StabilizedPalmPosition.z));
        Debug.Log("LearningPlayGestureRecognised");
    }
    private void ZoomInGestureRecognised(EasyLeapGesture2State state)
    {
        if (state == EasyLeapGesture2State.STATEINVALID || Time.time < doubleOutSwipeRestTime + EasyLeapGesture2.DoubleOutwardsRecoveryTime)
        {
            gestureList.Remove(-(int)EasyLeapGesture2Type.DOUBLE_SWIPE_OUT);
            return;
        }
        doubleOutSwipeRestTime = Time.time;
        RecordNewGesture(-(int)EasyLeapGesture2Type.DOUBLE_SWIPE_OUT, EasyLeapGesture2State.STATESTART, EasyLeapGesture2State.STATEUPDATE, EasyLeapGesture2Type.DOUBLE_SWIPE_OUT, -1, new Leap.Vector(mFrame.Hands[0].StabilizedPalmPosition.x + mFrame.Hands[1].StabilizedPalmPosition.x, mFrame.Hands[0].StabilizedPalmPosition.y, mFrame.Hands[0].StabilizedPalmPosition.z));
        Debug.Log("ZoomInGestureRecognised");
        //mAnimator = chracter.GetComponent<Animation>();
        //mAnimator.Play("kicking");
    }
    private void PushGestureRecognised(EasyLeapGesture2State state)
    {
        if (state == EasyLeapGesture2State.STATEINVALID || Time.time < pushRestTime + EasyLeapGesture2.PushRecoveryTime)
        {
            gestureList.Remove(-(int)EasyLeapGesture2Type.PUSH);
            return;
        }
        pushRestTime = Time.time;
        RecordNewGesture(-(int)EasyLeapGesture2Type.PUSH, EasyLeapGesture2State.STATESTART, EasyLeapGesture2State.STATEUPDATE, EasyLeapGesture2Type.PUSH, -1, mFrame.Hands[0].StabilizedPalmPosition);
        Debug.Log("SitGesture");
        //mAnimator = chracter.GetComponent<Animation>();
        // mAnimator.Play("punching");
    }
    private void PullGestureRecognised(EasyLeapGesture2State state)
    {
        if (state == EasyLeapGesture2State.STATEINVALID || Time.time < pullRestTime + EasyLeapGesture2.PullRecoveryTime)
        {
            gestureList.Remove(-(int)EasyLeapGesture2Type.PULL);
            return;
        }
        pullRestTime = Time.time;
        RecordNewGesture(-(int)EasyLeapGesture2Type.PULL, EasyLeapGesture2State.STATESTART, EasyLeapGesture2State.STATEUPDATE, EasyLeapGesture2Type.PULL, -1, mFrame.Hands[0].StabilizedPalmPosition);
        Debug.Log("JumpGesture");
        //mAnimator = chracter.GetComponent<Animation>();
        // mAnimator.Play("salute");
    }

    /*
    private void DoublePushGestureRecognised(EasyLeapGesture2State state)
    {
        if (state == EasyLeapGesture2State.STATEINVALID || Time.time < pushRestTime + EasyLeapGesture2.PushRecoveryTime)
        {
            gestureList.Remove(-(int)EasyLeapGesture2Type.DOUBLE_PUSH);
            return;
        }
        pushRestTime = Time.time;
        RecordNewGesture(-(int)EasyLeapGesture2Type.DOUBLE_PUSH, EasyLeapGesture2State.STATESTART, EasyLeapGesture2State.STATEUPDATE, EasyLeapGesture2Type.DOUBLE_PUSH, -1, mFrame.Hands[0].StabilizedPalmPosition);
        Debug.Log("DoublePushGestureRecognised");
        //mAnimator = chracter.GetComponent<Animation>();
        // mAnimator.Play("punching");
    }

 
    private void CloseFistGestureRecognised(EasyLeapGesture2State state) {
        if(EasyLeapGesture2State.STATEINVALID == state) {
            gestureList.Remove (-(int)EasyLeapGesture2Type.CLOSE_FIST);
            return;
        }
        if(state == EasyLeapGesture2State.STATESTOP && !gestureList.ContainsKey(-(int)EasyLeapGesture2Type.CLOSE_FIST)) return;
        RecordNewGesture(-(int)EasyLeapGesture2Type.CLOSE_FIST,
            EasyLeapGesture2State.STATESTART, 
            state == EasyLeapGesture2State.STATESTART ? EasyLeapGesture2State.STATEUPDATE : EasyLeapGesture2State.STATESTOP, 
            EasyLeapGesture2Type.CLOSE_FIST,
            -1,
            mFrame.Hands[0].StabilizedPalmPosition);
        Debug.Log("CloseFistGestureRecognised");
    }
    
    private void OpenFistGestureRecognised(EasyLeapGesture2State state) {
        if(EasyLeapGesture2State.STATEINVALID == state) {
            gestureList.Remove (-(int)EasyLeapGesture2Type.OPEN_FIST);
            return;
        }
        if(state == EasyLeapGesture2State.STATESTOP && !gestureList.ContainsKey(-(int)EasyLeapGesture2Type.OPEN_FIST)) return;
        RecordNewGesture(-(int)EasyLeapGesture2Type.OPEN_FIST,
            EasyLeapGesture2State.STATESTART, 
            state == EasyLeapGesture2State.STATESTART ? EasyLeapGesture2State.STATEUPDATE : EasyLeapGesture2State.STATESTOP, 
            EasyLeapGesture2Type.OPEN_FIST,
            -1,
            mFrame.Hands[0].StabilizedPalmPosition);
        Debug.Log("OpenFistGestureRecognised");
    }
 
    private void BuiltInImprovedGestureRecognised(Leap.Gesture gesture, EasyLeapGesture2Type type) {
        if(!gestureList.ContainsKey(-(int)type)) {
            RecordNewGesture(-(int)type,
                EasyLeapGesture2State.STATESTOP, 
                EasyLeapGesture2State.STATEUPDATE, 
                type,
                -1,
                gesture.Hands[0].StabilizedPalmPosition);
        }
    }
    private void BuiltInGestureRecognised(Leap.Gesture gesture, EasyLeapGesture2Type type) {
        RecordNewGesture(gesture.Id,ConvertGestureState(gesture.State),ConvertGestureState(gesture.State),type,gesture.Duration,gesture.Hands[0].StabilizedPalmPosition);
    }
    */
    private void GoStopRecognised(EasyLeapGesture2Type type) {
        if(type != EasyLeapGesture2Type.DEFAULT) {
            RecordNewGesture(-(int)type,EasyLeapGesture2State.STATESTART,EasyLeapGesture2State.STATEUPDATE,type,-1,mFrame.Hands[0].StabilizedPalmPosition);
        }
        if(gestureList.Count == 0) return;
        for(int ii =(int)EasyLeapGesture2Type.ONE; ii<=(int)EasyLeapGesture2Type.TEN; ii++) {
            if(type != (EasyLeapGesture2Type)(ii) && gestureList.ContainsKey(-ii)) {
                EasyLeapGesture2 g = gestureList[-ii];
                g.State = EasyLeapGesture2State.STATESTOP;
                gestureList[-(int)ii] = g;
            }
        }
    }

    private void LeftDirectionGestureRecognised(EasyLeapGesture2State state)
    {
        if (state == EasyLeapGesture2State.STATEINVALID || Time.time < pushRestTime + EasyLeapGesture2.PushRecoveryTime)
        {
            gestureList.Remove(-(int)EasyLeapGesture2Type.LEFT_DIRECTION);
            return;
        }
        pushRestTime = Time.time;
        RecordNewGesture(-(int)EasyLeapGesture2Type.LEFT_DIRECTION, EasyLeapGesture2State.STATESTART, EasyLeapGesture2State.STATEUPDATE, EasyLeapGesture2Type.LEFT_DIRECTION, -1, mFrame.Hands[0].StabilizedPalmPosition);
        Debug.Log("LeftDirectionGestureRecognised");
        //mAnimator = chracter.GetComponent<Animation>();
        // mAnimator.Play("punching");
    }

    private void RightDirectionGestureRecognised(EasyLeapGesture2State state)
    {
        if (state == EasyLeapGesture2State.STATEINVALID || Time.time < pushRestTime + EasyLeapGesture2.PushRecoveryTime)
        {
            gestureList.Remove(-(int)EasyLeapGesture2Type.RIGHT_DIRECTION);
            return;
        }
        pushRestTime = Time.time;
        RecordNewGesture(-(int)EasyLeapGesture2Type.RIGHT_DIRECTION, EasyLeapGesture2State.STATESTART, EasyLeapGesture2State.STATEUPDATE, EasyLeapGesture2Type.RIGHT_DIRECTION, -1, mFrame.Hands[0].StabilizedPalmPosition);
        Debug.Log("RightDirectionGestureRecognised");
        //mAnimator = chracter.GetComponent<Animation>();
        // mAnimator.Play("punching");
    }

    private void ShotGestureRecognised(EasyLeapGesture2Type type)
    {
        if (type != EasyLeapGesture2Type.DEFAULT)
        {
            RecordNewGesture(-(int)type, EasyLeapGesture2State.STATESTART, EasyLeapGesture2State.STATEUPDATE, type, -1, mFrame.Hands[0].StabilizedPalmPosition);
        }
        if (gestureList.Count == 0) return;
    }

    private void LeftRightRecognised(EasyLeapGesture2State state)
    {
        if (state == EasyLeapGesture2State.STATEINVALID || Time.time < clapRestTime + EasyLeapGesture2.ClapRecoveryTime)
        {
            gestureList.Remove(-(int)EasyLeapGesture2Type.LEFT_RIGHT);
            return;
        }
        clapRestTime = Time.time;
        RecordNewGesture(-(int)EasyLeapGesture2Type.LEFT_RIGHT, EasyLeapGesture2State.STATESTART, EasyLeapGesture2State.STATEUPDATE, EasyLeapGesture2Type.LEFT_RIGHT, -1, new Leap.Vector(mFrame.Hands[0].StabilizedPalmPosition.x + mFrame.Hands[1].StabilizedPalmPosition.x, mFrame.Hands[0].StabilizedPalmPosition.y, mFrame.Hands[0].StabilizedPalmPosition.z));
        Debug.Log("LEFT_RIGHT");
        //mAnimator = chracter.GetComponent<Animation>();
        //mAnimator.Play("rolling2");
    }
    private void RollGestureRecognised(EasyLeapGesture2State state)
    {
        if (state == EasyLeapGesture2State.STATEINVALID || Time.time < pushRestTime + EasyLeapGesture2.PushRecoveryTime)
        {
            gestureList.Remove(-(int)EasyLeapGesture2Type.ROLL);
            return;
        }
        pushRestTime = Time.time;
        RecordNewGesture(-(int)EasyLeapGesture2Type.ROLL, EasyLeapGesture2State.STATESTART, EasyLeapGesture2State.STATEUPDATE, EasyLeapGesture2Type.ROLL, -1, mFrame.Hands[0].StabilizedPalmPosition);
        Debug.Log("RollGestureRecognised");
        //mAnimator = chracter.GetComponent<Animation>();
        // mAnimator.Play("punching");
    }

    private void GoForwardRecognised(EasyLeapGesture2State state)
    {
        if (state == EasyLeapGesture2State.STATEINVALID || Time.time < clapRestTime + EasyLeapGesture2.ClapRecoveryTime)
        {
            gestureList.Remove(-(int)EasyLeapGesture2Type.GO);
            return;
        }
        clapRestTime = Time.time;
        RecordNewGesture(-(int)EasyLeapGesture2Type.GO, EasyLeapGesture2State.STATESTART, EasyLeapGesture2State.STATEUPDATE, EasyLeapGesture2Type.GO, -1, new Leap.Vector(mFrame.Hands[0].StabilizedPalmPosition.x + mFrame.Hands[1].StabilizedPalmPosition.x, mFrame.Hands[0].StabilizedPalmPosition.y, mFrame.Hands[0].StabilizedPalmPosition.z));
        Debug.Log("GoRecognised");
        //mAnimator = chracter.GetComponent<Animation>();
        //mAnimator.Play("rolling2");
    }

    private void StopRecognised(EasyLeapGesture2State state)
    {
        if (state == EasyLeapGesture2State.STATEINVALID || Time.time < clapRestTime + EasyLeapGesture2.ClapRecoveryTime)
        {
            gestureList.Remove(-(int)EasyLeapGesture2Type.STOP);
            return;
        }
        clapRestTime = Time.time;
        RecordNewGesture(-(int)EasyLeapGesture2Type.STOP, EasyLeapGesture2State.STATESTART, EasyLeapGesture2State.STATEUPDATE, EasyLeapGesture2Type.STOP, -1, new Leap.Vector(mFrame.Hands[0].StabilizedPalmPosition.x + mFrame.Hands[1].StabilizedPalmPosition.x, mFrame.Hands[0].StabilizedPalmPosition.y, mFrame.Hands[0].StabilizedPalmPosition.z));
        Debug.Log("GoRecognised");
        //mAnimator = chracter.GetComponent<Animation>();
        //mAnimator.Play("rolling2");
    }

    // Send Gestures to all registered listeners with gestures recognised on current frame
    private void SendGesturesToListeners()
    {
        Dictionary<int, EasyLeapGesture2> copy = new Dictionary<int, EasyLeapGesture2>(gestureList);
        foreach (KeyValuePair<int, EasyLeapGesture2> obj in copy)
        {
            if (GestureRecognised != null) GestureRecognised(obj.Value);
            if (obj.Value.State == EasyLeapGesture2State.STATESTOP) gestureList.Remove(obj.Key);
        }
    }

    // Auxiliary functions //
    private int GetFingerCount()
    {
        int count = 0;
        foreach (Leap.Finger finger in mFrame.Fingers)
        {
            if (Mathf.Rad2Deg * finger.Direction.AngleTo(finger.Hand.Direction) < EasyLeapGesture2.MaxAngleFinger
                && finger.Length > EasyLeapGesture2.MinDistanceFinger) count++;
        }
        return count;
    }

    private int GetLeftFingerCount()
    {
        int count = 0;
        foreach (Leap.Finger finger in mFrame.Hands.Leftmost.Fingers)
        {
            if (Mathf.Rad2Deg * finger.Direction.AngleTo(finger.Hand.Direction) < EasyLeapGesture2.MaxAngleFinger
                && finger.Length > EasyLeapGesture2.MinDistanceFinger) count++;
        }
        return count;
    }

    private int GetRightFingerCount()
    {
        int count = 0;
        foreach (Leap.Finger finger in mFrame.Hands.Rightmost.Fingers)
        {
            if (Mathf.Rad2Deg * finger.Direction.AngleTo(finger.Hand.Direction) < EasyLeapGesture2.MaxAngleFinger
                && finger.Length > EasyLeapGesture2.MinDistanceFinger) count++;
        }
        return count;
    }
    /*
	private EasyLeapGesture2State ConvertGestureState(Leap.Gesture.GestureState state) {
		switch(state) {
			case Leap.Gesture.GestureState.STATESTART:
				return EasyLeapGesture2State.STATESTART;
			case Leap.Gesture.GestureState.STATEUPDATE:
				return EasyLeapGesture2State.STATEUPDATE;
			case Leap.Gesture.GestureState.STATESTOP:
				return EasyLeapGesture2State.STATESTOP;
		}
		return EasyLeapGesture2State.STATEINVALID;
	}
	*/
    private bool PalmIsHorizontal(Leap.Hand hand)
    {
        return hand.PalmNormal.AngleTo(Leap.Vector.Down) * Mathf.Rad2Deg < EasyLeapGesture2.MaxAnglePalm &&
            Mathf.Abs(hand.StabilizedPalmPosition.x) < EasyLeapGesture2.MaxFieldPalm &&
            Mathf.Abs(hand.StabilizedPalmPosition.z) < EasyLeapGesture2.MaxFieldPalm;
    }

	IEnumerator PareteCorutine()
	{
		PareteTurm = false;

		yield return new WaitForSeconds (2);

		PareteTurm = true;
	}

	IEnumerator ClayPrefab()
	{
		PrefabCreat = false;

		yield return new WaitForSeconds (2);

		PrefabCreat = true;
	}
	IEnumerator SpringRewind()
	{
		yield return new WaitForSeconds (3.0f);
		//Rewind = true;
		GameObject.FindWithTag ("CLAY").GetComponent<MeshDeformer> ().springForce = 0.0f;
	}
}


// Structs and enums //
public struct EasyLeapGesture2
{
    public EasyLeapGesture2Type Type;
    public EasyLeapGesture2State State;
    public long Duration;
    public Leap.Frame Frame;
    public Leap.Vector Position;
    public int Id;
    public bool isRightHand;
    // configurable settings
    public static float MaxAngleFinger = 45f; // max angle to consider a pointable a finger
    public static float MinDistanceFinger = 25f; // min distance to consider a pointable a finger (away from hand)
    public static float MaxAnglePalm = 25f; // max angle to consider a hand horizontal
    public static float MaxFieldPalm = 180f; // max x and z to read palm pos
    public static float PullRecoveryTime = 0.2f; // min time in between pull gestures
    public static float PushRecoveryTime = 0.2f; // min time in between push gestures
    public static float MinPushPullVelocity = 350f; // min velocity to recognise push pull gestures
    public static float DoubleInwardsRecoveryTime = 0.2f; // min time in between double inwards swipe gestures
    public static float DoubleOutwardsRecoveryTime = 0.2f; // min time in between double outwards swipe gestures
    public static float MinSwipeVelocity = 200f; // min velocity to recognise double swipe gestures
    public static float MaxPalmDistance = 120f; // max distance between palms to consider together -double swipe
    public static float MinClapVelocity = 350f; // min velocity to recognise a clap gesture
    public static float MaxPalmClapDistance = 90f; // max distance between palms to consider together -clap
    public static float ClapRecoveryTime = 0.15f; // min time in between claps
    public static float ZeorSwipeVelocity = 0f;
}

public enum EasyLeapGesture2Type
{
    DEFAULT,
    TYPECIRCLE,
    TYPESWIPE,
    TYPEKEYTAP,
    TWO_FINGERS_KEYTAP,
    THREE_FINGERS_KEYTAP,
    TYPESCREENTAP,
    TWO_FINGERS_SCREENTAP,
    THREE_FINGERS_SCREENTAP,
    ONE,
    TWO,
    THREE,
    FOUR,
    FIVE,
    SIX,
    SEVEN,
    EIGHT,
    NINE,
    TEN,
    CLOSE_FIST,
    OPEN_FIST,
    PUSH,
    PULL,
    DOUBLE_SWIPE_IN,
    DOUBLE_SWIPE_OUT,
    CLAP,
    STEERING_WHEEL,
    NUM_OF_ITEMS,
    DOUBLE_PUSH,
    DOUBLE_PULL,
    PUSH_PULL,
    PULL_PUSH,
    LEFT_DIRECTION,
    RIGHT_DIRECTION,
    SHOT,
    LEFT_RIGHT,
    ROLL,
    GO,
    STOP,
    LEARNINGPLAY
}

public enum EasyLeapGesture2State
{
    STATEINVALID,
    STATESTART,
    STATEUPDATE,
    STATESTOP
}
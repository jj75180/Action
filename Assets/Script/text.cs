// public class Temp :
// {
//     PlayerController pi;
//     State animationClip;
//     public State_Idle idle;
//     public State_Run run;
//     public State_Attack01 attack01;
//     public State_Attack02 attack02;
//     public State_Attack03 attack03;
//     public State_Slide slide;
//     public State_Stand stand;
//     public State_Jump jump;
//     public State_Fall fall;
//     Animator animator;
//     int hash_Idle = Animator.StringToHash(AnimationString.idle);
//     int hash_Run = Animator.StringToHash(AnimationString.run);
//     int hash_attack01 =Animator.StringToHash(AnimationString.Attack01);
//     int hash_attack02 =Animator.StringToHash(AnimationString.Attack02);
//     int hash_attack03 =Animator.StringToHash(AnimationString.Attack03);
//     int hash_slide =Animator.StringToHash(AnimationString.Slide);
//     int hash_stand =Animator.StringToHash(AnimationString.Stand);
//     int hash_jump =Animator.StringToHash(AnimationString.Jump);
//     int hash_Fall =Animator.StringToHash(AnimationString.Fall);
    
//     private void Awake()
//     {
//         animator = GetComponent<Animator>();
//         pi =GetComponent<PlayerController>();

//         idle = new State_Idle(pi, animator, this, hash_Idle);
//         run = new State_Run(pi , animator, this, hash_Run);
//         attack01 = new State_Attack01(pi, animator,this,hash_attack01);
//         attack02 = new State_Attack02(pi, animator,this,hash_attack02);
//         attack03 = new State_Attack03(pi, animator,this,hash_attack03);
//         slide = new State_Slide(pi,animator,this,hash_slide);
//         stand = new State_Stand(pi,animator,this,hash_stand);
//         jump = new State_Jump(pi,animator,this,hash_jump);
//         fall =new State_Fall(pi,animator,this,hash_Fall);
//     }

//     private void Start() {
//         PlayClip(idle);
//     }
//     void PlayClip(State newState)
//     {
//         animationClip = newState;
//         animationClip.BeforeEnter();
//     }

//     private void Update()
//     {
//         animationClip.GameLogic();
//     }

//     private void FixedUpdate()
//     {
//         animationClip.PhysicsLogic();
//     }

//     public void ChangeTo(State newState)
//     {
//         animationClip.BeforeExit();
//         animationClip = newState;
//         animationClip.BeforeEnter();
//     }
// }
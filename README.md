* 유료 에셋 사용으로 인해 소스코드만 등록되어 있습니다.
* 2025년 1월 현재 계속해서 작업 중인 프로젝트입니다.

# 심마니
## 장르
- 3D 생존 RPG
## 게임 소개
- 몬스터들을 피해 목표치만큼의 산삼을 채집해 오래 살아남는 것이 목표인 게임입니다.
<table>
  <tr>
    <td><img src="./Clips/1.png" width="400"></td>
    <td><img src="./Clips/2.png" width="400"></td>
  </tr>
  <tr>
    <td><img src="./Clips/3.png" width="400"></td>
    <td><img src="./Clips/4.png" width="400"></td>
  </tr>
  <tr>
    <td><img src="./Clips/5.png" width="400"></td>
    <td><img src="./Clips/6.png" width="400"></td>
  </tr>
  <tr>
    <td><img src="./Clips/7.png" width="400"></td>
    <td><img src="./Clips/8.png" width="400"></td>
  </tr>
</table>

## 소개 영상
https://www.youtube.com/watch?v=pqw_-IGxv8Q

## 개발 목적
- Unity 3D 기술 활용
- 디버깅과 확장이 용이한 설계 지향
## 담당 파트
- 모든 클라이언트 프로그래밍
- 일부 에셋 편집
## 개발 환경
- Unity 2022.3.45f1
- Unity Universal RP(URP) 14.0.11
- Adobe Mixamo

  캐릭터 모델 리깅 및 애니메이션 추가에 활용
- Blender 4.2

  캐릭터 에셋 간단한 편집에 활용
## 작업 기간
- 2024년 10월 ~ 12월
## 빌드
- [구글 드라이브](https://drive.google.com/file/d/1BLxmyynvWDg6LR1g5DV5Ho8IA1CaVsni/view?usp=sharing)
- 데이터 저장/로드, 게임 오버, 서브 퀘스트 등은 작업 중에 있습니다.

<details>
<summary>조작법</summary>

- WASD: 이동  
- 마우스 이동: 카메라 방향 전환  
- 마우스 좌클릭: (무기 장착 시) 공격  
- Space Bar: 점프  
- Left Shift: 가속  
- I: 인벤토리창 열기  
- E: 상호작용  
- Enter: (산에서) 메뉴 씬으로 돌아가기  
- F1 ~ F4: 그래픽 옵션 변경(Low ~ Ultra)  

</details>

## 사용 에셋
- TextMeshPro
- Cinemachine
- Terrain Tools
- 문화체육관광부 메타버스 데이터랩

  플레이어 캐릭터 모델 에셋
- Nature Package - Forest Environment

  환경(Terrain, Tree, Grass) 에셋

- Firefly Flare

  ParticleSystem 기반 이펙트 에셋
- FastSky - Procedural Sky and Clouds URP

  SkyBox 에셋
- KHS - Naganeupseong Walled Town, Suncheon

  마을 오브젝트 모델 에셋
- Oni Demon-Samurai

  적 모델 에셋
- Bengal and African Tiger

  적 모델 에셋
- Campfires & Torches Models and FX!

  횃불 모델 에셋

## 주요 기능
### 1) 모듈 중심 설계
- 개요
  각 기능을 독립적인 모듈로 설계하여 재사용성과 유지보수성을 추구하였습니다.
  독립적인 모듈들이 게임 내 하나의 개체(Entity)를 형성합니다.

- 효과
  새로운 기능 추가 시 독립적인 모듈만 개발하여 쉽게 확장 가능.
  모듈 재사용을 통해 반복적인 코드 작성을 방지.
  개발 속도와 유지보수 효율성 향상.
  인터페이스를 사용해 모듈 대체 가능.
  
<details>
<summary>예시</summary>

| 모듈명         | 역할                                    |
| ------------- | ------------------------------------- |
| **AI**         | 적 캐릭터 등 NPC의 행동 상태를 관리 (Idle, Trace, Attack 등). |
| **CombatStater** | 전투 중 상태(Idle, Stiffened, Attacking 등) 관리. |
| **DamageReceiver** | 공격에 의한 피해 처리 및 피격 이벤트 발생.        |
| **DamageSender**   | 적 또는 플레이어의 공격 로직 처리.           |
| **Follower**       | 목표를 추적하고 이동 로직을 수행.            |
| **Jumper**         | 점프 동작을 관리.                        |
| **Mover**          | 유저 입력에 따른 기본 이동 처리 (걷기, 뛰기 등).             |
| **ProcessRunner**  | 자원 채집 등 상호작용 처리.               |
| **Rotator**        | 카메라 및 캐릭터 회전 처리.               |
| **TargetFinder**   | 목표(적, 플레이어 등)를 탐지.               |
| **Equipper**       | 장비 장착 및 해제 로직 처리.              |
| **FatigueController** | 피로도 시스템 관리 (스태미나 감소 등).      |

**활용 예**
| **개체**    | **모듈 이름**          | **설명**                                                                 |
|---------------|-----------------------|---------------------------------------------------------------------------|
| **Hero**      | IMover                | 플레이어의 이동 처리를 담당                                              |
|               | IJumper               | 점프 기능을 담당                                                         |
|               | IDamageReceiver       | 피격 이벤트 및 체력 관리                                                 |
|               | IEquipper             | 장비 착용 및 관리                                                        |
|               | ICombatStater         | 전투 상태 관리 (Idle, Attacking, Stiffened 등)                            |
|               | IProcessRunner        | 채집 등 특정 행동의 진행 처리                                            |
|               | ISprinter             | 플레이어의 달리기(스프린트) 상태 관리                                     |
| **Enemy**     | IFollower             | AI의 목표를 따라 이동하는 기능 관리                                      |
|               | ICombatStater         | 전투 상태 관리 (Idle, Attacking, Stiffened 등)                            |
|               | IDamageReceiver       | 피격 이벤트 및 체력 관리                                                 |
|               | IDamageSender         | 공격 이벤트 및 데미지 처리                                               |
|               | IEnemyAI              | AI의 상태 전환 및 행동 처리                                              |
|               | ITargetFinder         | 타겟 탐지 및 탐색 로직 처리                                              |

**플레이어 캐릭터(Hero)의 피격 처리 시퀀스**
<img src="./Clips/uml/01_damaged.png" width="400">

</details>


## 주요 사용 기술

| 항목명        | 설명      |
| ------------- | ------------- |
| Design Patterns  | - Factory Pattern: 객체 생성 로직을 캡슐화<br> - Singleton Pattern: 매니저 클래스 관리<br> - State Pattern: AI 상태 관리<br> - Command Pattern: 게임상 특정 동작들을 객체로 분리<br> - Strategy Pattern 응용: 오브젝트의 각 모듈을 인터페이스로 사용<br> - MVP Pattern: UI 요소들에 사용|
| UI Object Binding  | 자식 컴포넌트 자동 바인딩  |
| Object Pooling  | 자주 사용하는 Object를 Stack 기반으로 풀링  |
| Unity Editor Script  |  원본 에셋의 대규모 Collider 수정, CustomPropertyDrawer에 활용 |
| Scriptable Object  |  테스트 플레이 중 설정값 편집에 활용 |
| Extension Method  |  컴포넌트 바인딩, 리스트 중 랜덤 선택 등에 활용 |
| Avatar Mask |  3D 애니메이션에 활용 |

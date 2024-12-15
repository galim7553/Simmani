using GamePlay.Datas;
using GamePlay.Hubs;
using GamePlay.Modules;
using GamePlay.Presenters;
using GamePlay.Views;

namespace GamePlay.Scene
{
    public class StatusController
    {
        IStageModel _stageModel;
        ITimeCycleModel _timeCycleModel;
        HeroModel _heroModel;
        IInventoryModel _inventoryModel;
        IHotKeyGroupConfig _hotkeyGroupConfig;

        StageView _stageView;
        TimeCycleView _timeCycleView;
        HeroStatView _heroStatView;
        HotKeyGroupView _hotkeyGroupView;

        StagePresenter _stagePresenter;
        TimeCyclePresenter _timeCyclePresenter;
        HeroStatPresenter _heroStatPresenter;
        HotKeyGroupPresenter _hotkeyGroupPresenter;

        public StatusController(IStageModel stageModel, ITimeCycleModel timeCycleModel, HeroModel heroModel,
            IInventoryModel inventoryModel, IHotKeyGroupConfig hotKeyGroupConfig,
            StageView stageView, TimeCycleView timeCycleView, HeroStatView heroStatView,
            HotKeyGroupView hotKeyGroupView)
        {
            _stageModel = stageModel;
            _timeCycleModel = timeCycleModel;
            _heroModel = heroModel;
            _inventoryModel = inventoryModel;
            _hotkeyGroupConfig = hotKeyGroupConfig;

            _stageView = stageView;
            _timeCycleView = timeCycleView;
            _heroStatView = heroStatView;
            _hotkeyGroupView = hotKeyGroupView;

            Initialize();
        }

        void Initialize()
        {
            _stagePresenter = new StagePresenter(_stageModel, _stageView);
            _timeCyclePresenter = new TimeCyclePresenter(_timeCycleModel, _timeCycleView);
            _heroStatPresenter = new HeroStatPresenter(_heroModel, _heroStatView);
            _hotkeyGroupPresenter = new HotKeyGroupPresenter(_inventoryModel, _hotkeyGroupView, _hotkeyGroupConfig);
        }

        public void ExecuteHotKey(int index)
        {
            _hotkeyGroupPresenter.ExecuteHotKey(index);
        }

        public void Clear()
        {
            _stagePresenter.Clear();
            _timeCyclePresenter.Clear();
            _heroStatPresenter.Clear();
            _hotkeyGroupPresenter.Clear();
        }
    }
}


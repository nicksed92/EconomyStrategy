mergeInto(LibraryManager.library, {

  GetCurrentLanguageExtern: function () {
    getCurrentLanguage();
  },

  GetPlayerDataExtern: function () {
    getPlayerData();
  },

  SavePlayerDataExtern: function (data) {
    setPlayerData(UTF8ToString(data));
  },

  GetLanguageExtern: function () {
    getLanguage();
  },

  ShowVideoAdvExtern: function () {
    showVideoAdv();
  },

  ShowFeedbackExtern: function () {
    showFeedback();
  },  

});
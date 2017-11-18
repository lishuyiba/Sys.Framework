// Write your Javascript code.
var lsyWeb = function () {
    var now = new Date();
    return {
        getUser: function () {
            $.post("/user/getlogin?t=" + now.getTime(), function (data) {
                if (data) {
                    if (data.IsOk && data !== null) {
                        var user = data.Data;
                        $('.user-info').append(user.UserName);
                    }
                }
            });
        }
    }
}
//初始化
var lsyWeb = new lsyWeb();
//用户信息
lsyWeb.getUser();

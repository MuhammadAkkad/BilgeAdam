package com.example.twitter20.app.User;

public class User {

    public String Name;
    public String NickName;
    public String Account;
    public String Password;

    public User(String name, String nickName, String account, String password) {
        Name = name;
        NickName = nickName;
        Account = account;
        Password = password;
    }

    public User() {

    }

    //region Getters/Setters
    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getNickName() {
        return NickName;
    }

    public void setNickName(String nickName) {
        NickName = nickName;
    }

    public String getAccount() {
        return Account;
    }

    public void setAccount(String account) {
        Account = account;
    }

    public String getPassword() {
        return Password;
    }

    public void setPassword(String password) {
        Password = password;
    }
    //endregion
}

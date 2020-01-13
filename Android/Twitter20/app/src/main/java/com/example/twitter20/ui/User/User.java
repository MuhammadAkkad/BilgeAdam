package com.example.twitter20.ui.User;

public class User {

    String Name;
    String NickName;
    String Account;
    String Password;

    public User(String name, String nickName, String account, String password) {
        Name = name;
        NickName = nickName;
        Account = account;
        Password = password;
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

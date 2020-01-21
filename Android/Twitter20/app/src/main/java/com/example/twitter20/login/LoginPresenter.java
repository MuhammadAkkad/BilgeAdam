package com.example.twitter20.login;

import android.content.Context;
import android.content.SharedPreferences;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

import com.example.twitter20.DbContract;
import com.example.twitter20.DbHelper;
import com.example.twitter20.User.User;

public class LoginPresenter {

    //    private View view;
//    DbHelper dbHelper = new DbHelper(null);
//    SQLiteDatabase dbWrite;
//    SQLiteDatabase dbRead = dbHelper.getReadableDatabase();
    Context mContext;
    SharedPreferences pref = null;
    private User user;

    public LoginPresenter(Context context, User user) {
        this.user = user;
        this.mContext = context;
    }

    public boolean LogIn(String account, String password, SharedPreferences prefVal) {
        pref = prefVal;
        DbHelper dbHelper = new DbHelper(mContext);
        SQLiteDatabase dbWrite;
        SQLiteDatabase dbRead = dbHelper.getReadableDatabase();

        // TODO: handle loggedInUser authentication
        Cursor cursor = dbRead.rawQuery("SELECT * FROM user WHERE  account = " + "\'" + account + "\'" + " AND password = " + "\'" + password + "\'",
                null);

        int ID;
        String Name;
        String NickName;

        try {
            if (cursor.getCount() > 0) {
                while (cursor.moveToNext()) {
                    ID = cursor.getInt(cursor.getColumnIndexOrThrow("_id"));
                    Name = cursor.getString(cursor.getColumnIndexOrThrow(DbContract.UserEntry.COLUMN_NAME));
                    NickName = cursor.getString(cursor.getColumnIndexOrThrow(DbContract.UserEntry.COLUMN_NICKNAME));
                    pref.edit().putInt("ID", ID).apply();
                    pref.edit().putString("Name", Name).apply();
                    pref.edit().putString("NickName", NickName).apply();
                }
                cursor.close();
                return true;
            } else return false;
        } catch (Exception e) {
            return false;
        }

    }

}

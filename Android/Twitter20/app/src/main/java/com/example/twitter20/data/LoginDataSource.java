package com.example.twitter20.data;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

import com.example.twitter20.DbHelper;
import com.example.twitter20.data.model.LoggedInUser;
import com.example.twitter20.ui.Register.RegisterFragment;

import java.io.IOException;

/**
 * Class that handles authentication w/ login credentials and retrieves user information.
 */
public class LoginDataSource {
    DbHelper dbHelper;
    SQLiteDatabase dbWrite;
    SQLiteDatabase dbRead;


    public boolean login(Context context, String username, String password) {
        dbHelper = new DbHelper(context);
        dbRead = dbHelper.getReadableDatabase();
        try {
            // TODO: handle loggedInUser authentication
            Cursor cursor = dbRead.rawQuery("SELECT * FROM user WHERE  account = " + "\'"+username +"\'"+ " AND password = " +"\'"+password +"\'",

                    null);
            if (cursor.getCount() > 0) {
                cursor.close();
                return true;
            }

        } catch (Exception e) {
            return false;
        }
        return false;
    }

    public void logout() {
        // TODO: revoke authentication
    }
}

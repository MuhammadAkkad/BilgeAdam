package com.example.twitter20.ui.Register;

import androidx.appcompat.app.AppCompatActivity;

import android.content.ContentValues;
import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.example.twitter20.FeedReaderContract;
import com.example.twitter20.FeedReaderDbHelper;
import com.example.twitter20.R;
import com.example.twitter20.ui.login.LoginActivity;


public class RegisterFragment extends AppCompatActivity {
    FeedReaderDbHelper dbHelper;
    SQLiteDatabase dbWrite;
    Button btn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register_fragment);
        dbHelper = new FeedReaderDbHelper(this);
        dbWrite = dbHelper.getWritableDatabase();
        btn = findViewById(R.id.Sign_up);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                RegisterNewUser(v);
            }
        });
    }

    public void RegisterNewUser(View view){
    TextView name = findViewById(R.id.name);
    TextView nickName = findViewById(R.id.nickname);
    TextView account = findViewById(R.id.account);
    TextView password = findViewById(R.id.password);

    String mName, mNickName, mAccount, mPassword;
    mName = name.getText().toString();
    mNickName = nickName.getText().toString();
    mAccount = account.getText().toString();
    mPassword = password.getText().toString();

    ContentValues values = new ContentValues();
        values.put(FeedReaderContract.UserEntry.COLUMN_NAME, mName);
        values.put(FeedReaderContract.UserEntry.COLUMN_NICKNAME, mNickName);
        values.put(FeedReaderContract.UserEntry.COLUMN_ACCOUNT, mAccount);
        values.put(FeedReaderContract.UserEntry.COLUMN_PASSWORD, mPassword);

        long newRowId = dbWrite.insert(FeedReaderContract.UserEntry.TABLE_NAME, null, values);
        Toast.makeText(this, "User Added", Toast.LENGTH_SHORT).show();

        if(newRowId != -1){
            Intent i = new Intent(getApplicationContext(), LoginActivity.class);
            startActivity(i);
        }


    }
}

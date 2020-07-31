using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadSignal : MonoBehaviour
{
	public List<Spawn> spawnList;
	public GameObject spawnPoint60;
	public GameObject spawnPoint72;
	public GameObject spawnPoint84;
	public float boxDelayTime;
	int spawnIndex;
	float currentDelayTime;


	private void Start()
	{
		spawnList = new List<Spawn>();
		ReadSpawnFile();
	}

	void ReadSpawnFile()
	{
		// 변수 초기화
		spawnList.Clear();
		spawnIndex = 0;

		// 리스폰 파일 읽기
		TextAsset textFile = Resources.Load("dontstartnowFull") as TextAsset;
		StringReader stringReader = new StringReader(textFile.text);

		// 글자 배열이 없을때까지
		while (stringReader != null)
		{
			string line = stringReader.ReadLine(); //텍스트의 내용을 한줄씩 읽어 온다.
			if (line == null)
				break;

			// 리스폰 데이터 생성
			Spawn spawnData = new Spawn();
			spawnData.delay = float.Parse(line.Split(',')[0]) / 1000; // 1. 시간 판단
			spawnData.OnOff = line.Split(',')[1];// 3. on off 변경
			spawnData.channel = int.Parse(line.Split(',')[2]);
			spawnData.location = int.Parse(line.Split(',')[3]);// 2. 60,72 판단
			spawnData.velocity = int.Parse(line.Split(',')[4]);
			spawnList.Add(spawnData);
		}

		//텍스트 파일 닫기
		stringReader.Close();

	}

	private void Update()
	{
		currentDelayTime += (1 - 0.04f) * Time.deltaTime; // 스폰 시간 증가

		if (spawnIndex < spawnList.Count) // 배열의 모든 값이 출력 되고 나면 나오지 않도록 하기 위해 
		{
			// 만약 현재 시간이 텍스트에 적혀있는 시간보다 크다면 , boxDelay = 박스가 생성되서 도착지점까지 걸리는 시간.
			if (currentDelayTime > spawnList[spawnIndex].delay - boxDelayTime)
			{
				print(currentDelayTime);
				SpawnManage(); // SpawnManager 실행
			}
		}
	}

	void SpawnManage()
	{
		int setSpawn = 0;

		//스위치 문을 통해 OnOff 상태확인
		switch (spawnList[spawnIndex].OnOff)
		{
			case "On":
				setSpawn = 1;
				break;
			case "Off":
				setSpawn = 2;
				break;
		}

		// 만약 스폰 위치가 60이라면
		if (spawnList[spawnIndex].location == 60 && spawnPoint60 != null)
		{
			if (setSpawn == 1) spawnPoint60.SetActive(true); //On 이라면 켜주고
			if (setSpawn == 2) spawnPoint60.SetActive(false); //Off 라면 꺼준다.
		}


		if (spawnList[spawnIndex].location == 72 && spawnPoint72 != null)
		{
			if (setSpawn == 1) spawnPoint72.SetActive(true);
			if (setSpawn == 2) spawnPoint72.SetActive(false);
		}

		if (spawnList[spawnIndex].location == 84 && spawnPoint84 != null)
		{
			if (setSpawn == 1) spawnPoint84.SetActive(true);
			if (setSpawn == 2) spawnPoint84.SetActive(false);
		}

		spawnIndex++; //그 다음 줄로 이동한다.

	}

}

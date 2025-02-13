Sql sunucu bağlantısı için sunucu ismi (local) olarak ayarlanmıştır.
Sql bağlantısı için web.config scripttine şöyle bir kod yazılmıştır ihtiyaca göre data source kısmını değiştirin : 	
<connectionStrings>
		<add name="GorevContext" connectionString="Data Source=(local);Initial Catalog=TaskManagementDB;Integrated Security=True" providerName="System.Data.SqlClient" />
	</connectionStrings>


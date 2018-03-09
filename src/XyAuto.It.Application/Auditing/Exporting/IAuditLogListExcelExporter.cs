using System.Collections.Generic;
using XyAuto.It.Auditing.Dto;
using XyAuto.It.Dto;

namespace XyAuto.It.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}

